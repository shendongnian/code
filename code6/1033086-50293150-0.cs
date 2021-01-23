    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Http.SelfHost;
    using CERTENROLLLib;
    namespace SelfhostSSLProofOfConcept
    {
        /// <summary>
        /// Add Reference: COM > TypeLibraries > CertEnroll 1.0 Type Library
        /// </summary>
        class Program
        {
            static void Main(string[] args)
            {
                var port = 1234;
                var cert = GenerateCert();
                Console.WriteLine("{0}Thumbprint: {1}{0}", Environment.NewLine, cert.Thumbprint);
                RegisterSslOnPort(port);
                var config = new HttpSelfHostConfiguration($"https://localhost:{port}");
                var server = new HttpSelfHostServer(config, new MyWebAPIMessageHandler());
                var task = server.OpenAsync();
                task.Wait();
                Process.Start($"https://localhost:{port}"); // automatically open browser
                Console.WriteLine($"Web API Server has started at https://localhost:{port}");
                Console.ReadLine();
            }
            private static void RegisterSslOnPort(int port)
            {
                string arguments = $"http add sslcert ipport=0.0.0.0:{port} certhash=1A757426C3ECA4148DF207DAA611587DDBB7686A appid={{a72d06a2-8734-4c25-88bb-7a8076178232}}";
                ProcessStartInfo procStartInfo = new ProcessStartInfo("netsh", arguments);
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                var process = Process.Start(procStartInfo);
                while (!process.StandardOutput.EndOfStream)
                {
                    string line = process.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                }
                process.WaitForExit();
            }
            public static X509Certificate2 GenerateCert()
            {
                var certName = "Your Cert Subject Name";
                var store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadWrite);
                var existingCert = store.Certificates.Find(X509FindType.FindBySubjectName, certName, false);
                if (existingCert.Count > 0)
                {
                    store.Close();
                    return existingCert[0];
                }
                else
                {
                    var cert = CreateSelfSignedCertificate(certName);
                    store.Add(cert);
                    store.Close();
                    return cert;
                }
            }
            /// <summary>
            /// Add Reference: COM > TypeLibraries > CertEnroll 1.0 Type Library
            /// </summary>
            /// <param name="subjectName"></param>
            /// <returns></returns>
            public static X509Certificate2 CreateSelfSignedCertificate(string subjectName)
            {
                // create DN for subject and issuer
                var dn = new CX500DistinguishedName();
                dn.Encode("CN=" + subjectName, X500NameFlags.XCN_CERT_NAME_STR_NONE);
                // create a new private key for the certificate
                CX509PrivateKey privateKey = new CX509PrivateKey();
                privateKey.ProviderName = "Microsoft Base Cryptographic Provider v1.0";
                privateKey.MachineContext = true;
                privateKey.Length = 2048;
                privateKey.KeySpec = X509KeySpec.XCN_AT_SIGNATURE; // use is not limited
                privateKey.ExportPolicy = X509PrivateKeyExportFlags.XCN_NCRYPT_ALLOW_PLAINTEXT_EXPORT_FLAG;
                privateKey.Create();
                // Use the stronger SHA512 hashing algorithm
                var hashobj = new CObjectId();
                hashobj.InitializeFromAlgorithmName(ObjectIdGroupId.XCN_CRYPT_HASH_ALG_OID_GROUP_ID,
                    ObjectIdPublicKeyFlags.XCN_CRYPT_OID_INFO_PUBKEY_ANY,
                    AlgorithmFlags.AlgorithmFlagsNone, "SHA512");
                // add extended key usage if you want - look at MSDN for a list of possible OIDs
                var oid = new CObjectId();
                oid.InitializeFromValue("1.3.6.1.5.5.7.3.1"); // SSL server
                var oidlist = new CObjectIds();
                oidlist.Add(oid);
                var eku = new CX509ExtensionEnhancedKeyUsage();
                eku.InitializeEncode(oidlist);
                // Create the self signing request
                var cert = new CX509CertificateRequestCertificate();
                cert.InitializeFromPrivateKey(X509CertificateEnrollmentContext.ContextMachine, privateKey, "");
                cert.Subject = dn;
                cert.Issuer = dn; // the issuer and the subject are the same
                cert.NotBefore = DateTime.Now;
                // this cert expires immediately. Change to whatever makes sense for you
                cert.NotAfter = DateTime.Now;
                cert.X509Extensions.Add((CX509Extension)eku); // add the EKU
                cert.HashAlgorithm = hashobj; // Specify the hashing algorithm
                cert.Encode(); // encode the certificate
                // Do the final enrollment process
                var enroll = new CX509Enrollment();
                enroll.InitializeFromRequest(cert); // load the certificate
                enroll.CertificateFriendlyName = subjectName; // Optional: add a friendly name
                string csr = enroll.CreateRequest(); // Output the request in base64
                // and install it back as the response
                enroll.InstallResponse(InstallResponseRestrictionFlags.AllowUntrustedCertificate,
                    csr, EncodingType.XCN_CRYPT_STRING_BASE64, ""); // no password
                // output a base64 encoded PKCS#12 so we can import it back to the .Net security classes
                var base64encoded = enroll.CreatePFX("", // no password, this is for internal consumption
                    PFXExportOptions.PFXExportChainWithRoot);
                // instantiate the target class with the PKCS#12 data (and the empty password)
                return new System.Security.Cryptography.X509Certificates.X509Certificate2(
                    System.Convert.FromBase64String(base64encoded), "",
                    // mark the private key as exportable (this is usually what you want to do)
                    System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.Exportable
                );
            }
        }
        class MyWebAPIMessageHandler : HttpMessageHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                var task = new Task<HttpResponseMessage>(() => {
                    var resMsg = new HttpResponseMessage();
                    resMsg.Content = new StringContent("Hello World!");
                    return resMsg;
                });
                task.Start();
                return task;
            }
        }
    }
