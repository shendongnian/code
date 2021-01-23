    using System;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    namespace Utilities
    {
        internal static class SignTool
        {
            #region Structures
            [StructLayoutAttribute(LayoutKind.Sequential)]
            struct SIGNER_SUBJECT_INFO
            {
                public uint cbSize;
                public IntPtr pdwIndex;
                public uint dwSubjectChoice;
                public SubjectChoiceUnion Union1;
                [StructLayoutAttribute(LayoutKind.Explicit)]
                internal struct SubjectChoiceUnion
                {
                    [FieldOffsetAttribute(0)]
                    public System.IntPtr pSignerFileInfo;
                    [FieldOffsetAttribute(0)]
                    public System.IntPtr pSignerBlobInfo;
                };
            }
            [StructLayoutAttribute(LayoutKind.Sequential)]
            struct SIGNER_CERT
            {
                public uint cbSize;
                public uint dwCertChoice;
                public SignerCertUnion Union1;
                [StructLayoutAttribute(LayoutKind.Explicit)]
                internal struct SignerCertUnion
                {
                    [FieldOffsetAttribute(0)]
                    public IntPtr pwszSpcFile;
                    [FieldOffsetAttribute(0)]
                    public IntPtr pCertStoreInfo;
                    [FieldOffsetAttribute(0)]
                    public IntPtr pSpcChainInfo;
                };
                public IntPtr hwnd;
            }
            [StructLayoutAttribute(LayoutKind.Sequential)]
            struct SIGNER_SIGNATURE_INFO
            {
                public uint cbSize;
                public uint algidHash; // ALG_ID
                public uint dwAttrChoice;
                public IntPtr pAttrAuthCode;
                public IntPtr psAuthenticated; // PCRYPT_ATTRIBUTES
                public IntPtr psUnauthenticated; // PCRYPT_ATTRIBUTES
            }
            [StructLayoutAttribute(LayoutKind.Sequential)]
            struct SIGNER_FILE_INFO
            {
                public uint cbSize;
                public IntPtr pwszFileName;
                public IntPtr hFile;
            }
            [StructLayoutAttribute(LayoutKind.Sequential)]
            struct SIGNER_CERT_STORE_INFO
            {
                public uint cbSize;
                public IntPtr pSigningCert; // CERT_CONTEXT
                public uint dwCertPolicy;
                public IntPtr hCertStore;
            }
            [StructLayoutAttribute(LayoutKind.Sequential)]
            struct SIGNER_PROVIDER_INFO
            {
                public uint cbSize;
                public IntPtr pwszProviderName;
                public uint dwProviderType;
                public uint dwKeySpec;
                public uint dwPvkChoice;
                public SignerProviderUnion Union1;
                [StructLayoutAttribute(LayoutKind.Explicit)]
                internal struct SignerProviderUnion
                {
                    [FieldOffsetAttribute(0)]
                    public IntPtr pwszPvkFileName;
                    [FieldOffsetAttribute(0)]
                    public IntPtr pwszKeyContainer;
                };
            }
            
            #endregion
            #region Imports
            [DllImport("Mssign32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern int SignerSign(
                IntPtr pSubjectInfo,        // SIGNER_SUBJECT_INFO
                IntPtr pSignerCert,         // SIGNER_CERT
                IntPtr pSignatureInfo,      // SIGNER_SIGNATURE_INFO
                IntPtr pProviderInfo,       // SIGNER_PROVIDER_INFO
                string pwszHttpTimeStamp,   // LPCWSTR
                IntPtr psRequest,           // PCRYPT_ATTRIBUTES
                IntPtr pSipData             // LPVOID 
                );
        
            [DllImport("Mssign32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern int SignerSignEx(
                uint dwFlags,               // DWORD
                IntPtr pSubjectInfo,        // SIGNER_SUBJECT_INFO
                IntPtr pSignerCert,         // SIGNER_CERT
                IntPtr pSignatureInfo,      // SIGNER_SIGNATURE_INFO
                IntPtr pProviderInfo,       // SIGNER_PROVIDER_INFO
                string pwszHttpTimeStamp,   // LPCWSTR
                IntPtr psRequest,           // PCRYPT_ATTRIBUTES
                IntPtr pSipData,            // LPVOID 
                out IntPtr ppSignerContext  // SIGNER_CONTEXT
                );
            [DllImport("Mssign32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern int SignerTimeStamp(
                IntPtr pSubjectInfo,        // SIGNER_SUBJECT_INFO
                string pwszHttpTimeStamp,   // LPCWSTR
                IntPtr psRequest,           // PCRYPT_ATTRIBUTES
                IntPtr pSipData             // LPVOID 
                );
            [DllImport("Mssign32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern int SignerTimeStampEx(
                uint dwFlags,               // DWORD
                IntPtr pSubjectInfo,        // SIGNER_SUBJECT_INFO
                string pwszHttpTimeStamp,   // LPCWSTR
                IntPtr psRequest,           // PCRYPT_ATTRIBUTES
                IntPtr pSipData,            // LPVOID
                out IntPtr ppSignerContext  // SIGNER_CONTEXT
                );
            [DllImport("Crypt32.DLL", EntryPoint = "CertCreateCertificateContext", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
            private static extern IntPtr CertCreateCertificateContext(
                int dwCertEncodingType,
                byte[] pbCertEncoded,
                int cbCertEncoded);
            #endregion
            #region Public Methods
            // Call SignerSignEx and SignerTimeStampEx for a given .pfx
            public static void SignWithCert(string appPath, string certPath, string certPassword, string timestampUrl)
            {
                IntPtr pSignerCert = IntPtr.Zero;
                IntPtr pSubjectInfo = IntPtr.Zero;
                IntPtr pSignatureInfo = IntPtr.Zero;
                IntPtr pProviderInfo = IntPtr.Zero;
                try
                {
                    X509Certificate2 cert = new X509Certificate2(certPath, certPassword);
                    pSignerCert = CreateSignerCert(cert);
                    pSubjectInfo = CreateSignerSubjectInfo(appPath);
                    pSignatureInfo = CreateSignerSignatureInfo();
                    pProviderInfo = GetProviderInfo(cert);
                    IntPtr signerContext;
                    SignCode(0x0, pSubjectInfo, pSignerCert, pSignatureInfo, pProviderInfo, out signerContext);
                    if (!string.IsNullOrEmpty(timestampUrl))
                    {
                        TimeStampSignedCode(0x0, pSubjectInfo, timestampUrl, out signerContext);
                    }
                }
                catch (Exception e)
                {
                    // do anything?
                    string exception = e.Message;
                }
                finally
                {
                    if (pSignerCert != IntPtr.Zero)
                    {
                        Marshal.DestroyStructure(pSignerCert, typeof(SIGNER_CERT));
                    }
                    if (pSubjectInfo != IntPtr.Zero)
                    {
                        Marshal.DestroyStructure(pSubjectInfo, typeof(SIGNER_SUBJECT_INFO));
                    }
                    if (pSignatureInfo != IntPtr.Zero)
                    {
                        Marshal.DestroyStructure(pSignatureInfo, typeof(SIGNER_SIGNATURE_INFO));
                    }
                    if (pProviderInfo != IntPtr.Zero)
                    {
                        Marshal.DestroyStructure(pSignatureInfo, typeof(SIGNER_PROVIDER_INFO));
                    }
                }
            }
            // Call SignerSign and SignerTimeStamp for a given thumbprint.
            public static void SignWithThumbPrint(string appPath, string thumbPrint, string timestampUrl)
            {
                IntPtr pSignerCert = IntPtr.Zero;
                IntPtr pSubjectInfo = IntPtr.Zero;
                IntPtr pSignatureInfo = IntPtr.Zero;
                IntPtr pProviderInfo = IntPtr.Zero;
                try
                {
                    pSignerCert = CreateSignerCert(thumbPrint);
                    pSubjectInfo = CreateSignerSubjectInfo(appPath);
                    pSignatureInfo = CreateSignerSignatureInfo();
                    SignCode(pSubjectInfo, pSignerCert, pSignatureInfo, pProviderInfo);
                    if (!string.IsNullOrEmpty(timestampUrl))
                    {
                        TimeStampSignedCode(pSubjectInfo, timestampUrl);
                    }
                }
                catch
                {
                    // do anything?
                }
                finally
                {
                    if (pSignerCert != IntPtr.Zero)
                    {
                        Marshal.DestroyStructure(pSignerCert, typeof(SIGNER_CERT));
                    }
                    if (pSubjectInfo != IntPtr.Zero)
                    {
                        Marshal.DestroyStructure(pSubjectInfo, typeof(SIGNER_SUBJECT_INFO));
                    }
                    if (pSignatureInfo != IntPtr.Zero)
                    {
                        Marshal.DestroyStructure(pSignatureInfo, typeof(SIGNER_SIGNATURE_INFO));
                    }
                }
            }
            #endregion
            #region Private Methods
            private static IntPtr CreateSignerSubjectInfo(string pathToAssembly)
            {
                SIGNER_SUBJECT_INFO info = new SIGNER_SUBJECT_INFO
                {
                    cbSize = (uint)Marshal.SizeOf(typeof(SIGNER_SUBJECT_INFO)),
                    pdwIndex = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(uint)))
                };
                var index = 0;
                Marshal.StructureToPtr(index, info.pdwIndex, false);
                info.dwSubjectChoice = 0x1; //SIGNER_SUBJECT_FILE
                IntPtr assemblyFilePtr = Marshal.StringToHGlobalUni(pathToAssembly);
                SIGNER_FILE_INFO fileInfo = new SIGNER_FILE_INFO
                {
                    cbSize = (uint)Marshal.SizeOf(typeof(SIGNER_FILE_INFO)),
                    pwszFileName = assemblyFilePtr,
                    hFile = IntPtr.Zero
                };
                info.Union1 = new SIGNER_SUBJECT_INFO.SubjectChoiceUnion
                {
                    pSignerFileInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SIGNER_FILE_INFO)))
                };
                Marshal.StructureToPtr(fileInfo, info.Union1.pSignerFileInfo, false);
                IntPtr pSubjectInfo = Marshal.AllocHGlobal(Marshal.SizeOf(info));
                Marshal.StructureToPtr(info, pSubjectInfo, false);
                return pSubjectInfo;
            }
            private static X509Certificate2 FindCertByThumbPrint(string thumbPrint)
            {
                try
                {
                    // Check common store locations for the corresponding code-signing cert.
                    X509Store[] stores = new X509Store[4] { new X509Store(StoreName.My, StoreLocation.CurrentUser),
                                                            new X509Store(StoreName.TrustedPublisher, StoreLocation.CurrentUser),
                                                            new X509Store(StoreName.My, StoreLocation.LocalMachine),
                                                            new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine) };
                    foreach (X509Store store in stores)
                    {
                        store.Open(OpenFlags.ReadOnly);
                        X509Certificate2Collection certs = store.Certificates.Find(X509FindType.FindByThumbprint, thumbPrint, false);
                        store.Close();
                        if (certs.Count != 1)
                        {
                            continue;
                        }
                        return certs[0];
                    }
                    return null;
                }
                catch (Exception e)
                {
                    throw new Exception(string.Format("Error locating certificate", e));
                }
            }
            private static IntPtr CreateSignerCert(X509Certificate2 cert)
            {
                SIGNER_CERT signerCert = new SIGNER_CERT
                {
                    cbSize = (uint)Marshal.SizeOf(typeof(SIGNER_CERT)),
                    dwCertChoice = 0x2,
                    Union1 = new SIGNER_CERT.SignerCertUnion
                    {
                        pCertStoreInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SIGNER_CERT_STORE_INFO)))
                    },
                    hwnd = IntPtr.Zero
                };
                const int X509_ASN_ENCODING = 0x00000001;
                const int PKCS_7_ASN_ENCODING = 0x00010000;
                IntPtr pCertContext = CertCreateCertificateContext(
                    X509_ASN_ENCODING | PKCS_7_ASN_ENCODING,
                    cert.GetRawCertData(),
                    cert.GetRawCertData().Length);
                SIGNER_CERT_STORE_INFO certStoreInfo = new SIGNER_CERT_STORE_INFO
                {
                    cbSize = (uint)Marshal.SizeOf(typeof(SIGNER_CERT_STORE_INFO)),
                    pSigningCert = pCertContext,
                    dwCertPolicy = 0x2, // SIGNER_CERT_POLICY_CHAIN
                    hCertStore = IntPtr.Zero
                };
                Marshal.StructureToPtr(certStoreInfo, signerCert.Union1.pCertStoreInfo, false);
                IntPtr pSignerCert = Marshal.AllocHGlobal(Marshal.SizeOf(signerCert));
                Marshal.StructureToPtr(signerCert, pSignerCert, false);
                return pSignerCert;
            }
            private static IntPtr CreateSignerCert(string thumbPrint)
            {
                SIGNER_CERT signerCert = new SIGNER_CERT
                {
                    cbSize = (uint)Marshal.SizeOf(typeof(SIGNER_CERT)),
                    dwCertChoice = 0x2,
                    Union1 = new SIGNER_CERT.SignerCertUnion
                    {
                        pCertStoreInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SIGNER_CERT_STORE_INFO)))
                    },
                    hwnd = IntPtr.Zero
                };
                const int X509_ASN_ENCODING = 0x00000001;
                const int PKCS_7_ASN_ENCODING = 0x00010000;
                X509Certificate2 cert = FindCertByThumbPrint(thumbPrint);
                IntPtr pCertContext = CertCreateCertificateContext(
                    X509_ASN_ENCODING | PKCS_7_ASN_ENCODING,
                    cert.GetRawCertData(),
                    cert.GetRawCertData().Length);
                SIGNER_CERT_STORE_INFO certStoreInfo = new SIGNER_CERT_STORE_INFO
                {
                    cbSize = (uint)Marshal.SizeOf(typeof(SIGNER_CERT_STORE_INFO)),
                    pSigningCert = pCertContext,
                    dwCertPolicy = 0x2, // SIGNER_CERT_POLICY_CHAIN
                    hCertStore = IntPtr.Zero
                };
                Marshal.StructureToPtr(certStoreInfo, signerCert.Union1.pCertStoreInfo, false);
                IntPtr pSignerCert = Marshal.AllocHGlobal(Marshal.SizeOf(signerCert));
                Marshal.StructureToPtr(signerCert, pSignerCert, false);
                return pSignerCert;
            }
            private static IntPtr CreateSignerSignatureInfo()
            {
                SIGNER_SIGNATURE_INFO signatureInfo = new SIGNER_SIGNATURE_INFO
                {
                    cbSize = (uint)Marshal.SizeOf(typeof(SIGNER_SIGNATURE_INFO)),
                    algidHash = 0x00008004, // CALG_SHA1
                    dwAttrChoice = 0x0, // SIGNER_NO_ATTR
                    pAttrAuthCode = IntPtr.Zero,
                    psAuthenticated = IntPtr.Zero,
                    psUnauthenticated = IntPtr.Zero
                };
                IntPtr pSignatureInfo = Marshal.AllocHGlobal(Marshal.SizeOf(signatureInfo));
                Marshal.StructureToPtr(signatureInfo, pSignatureInfo, false);
                return pSignatureInfo;
            }
            private static IntPtr GetProviderInfo(X509Certificate2 cert)
            {
                if (cert == null || !cert.HasPrivateKey)
                {
                    return IntPtr.Zero;
                }
                ICspAsymmetricAlgorithm key = (ICspAsymmetricAlgorithm)cert.PrivateKey;
                const int PVK_TYPE_KEYCONTAINER = 2;
                if (key == null)
                {
                    return IntPtr.Zero;
                }
                SIGNER_PROVIDER_INFO providerInfo = new SIGNER_PROVIDER_INFO
                {
                    cbSize = (uint)Marshal.SizeOf(typeof(SIGNER_PROVIDER_INFO)),
                    pwszProviderName = Marshal.StringToHGlobalUni(key.CspKeyContainerInfo.ProviderName),
                    dwProviderType = (uint)key.CspKeyContainerInfo.ProviderType,
                    dwPvkChoice = PVK_TYPE_KEYCONTAINER,
                    Union1 = new SIGNER_PROVIDER_INFO.SignerProviderUnion
                    {
                        pwszKeyContainer = Marshal.StringToHGlobalUni(key.CspKeyContainerInfo.KeyContainerName)
                    },
                };
                IntPtr pProviderInfo = Marshal.AllocHGlobal(Marshal.SizeOf(providerInfo));
                Marshal.StructureToPtr(providerInfo, pProviderInfo, false);
                return pProviderInfo;
            }
        
            // SignerSign
            private static void SignCode(IntPtr pSubjectInfo, IntPtr pSignerCert, IntPtr pSignatureInfo, IntPtr pProviderInfo)
            {
                int hResult = SignerSign(
                    pSubjectInfo,
                    pSignerCert,
                    pSignatureInfo,
                    pProviderInfo,
                    null,
                    IntPtr.Zero,
                    IntPtr.Zero
                    );
                if (hResult != 0)
                {
                    // See if we can get anything useful.
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                }
            }
            // SignerSignEx
            private static void SignCode(uint dwFlags, IntPtr pSubjectInfo, IntPtr pSignerCert, IntPtr pSignatureInfo, IntPtr pProviderInfo, out IntPtr signerContext)
            {
                int hResult = SignerSignEx(
                    dwFlags,
                    pSubjectInfo,
                    pSignerCert,
                    pSignatureInfo,
                    pProviderInfo,
                    null,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    out signerContext
                    );
                if (hResult != 0)
                {
                    // See if we can get anything useful.
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                }
            }
            // SignerTimeStamp
            private static void TimeStampSignedCode(IntPtr pSubjectInfo, string timestampUrl)
            {
                int hResult = SignerTimeStamp(
                    pSubjectInfo,
                    timestampUrl,
                    IntPtr.Zero,
                    IntPtr.Zero
                    );
                if (hResult != 0)
                {
                    // See if we can get anything useful.
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                }
            }
            // SignerTimeStampEx
            private static void TimeStampSignedCode(uint dwFlags, IntPtr pSubjectInfo, string timestampUrl, out IntPtr signerContext)
            {
                int hResult = SignerTimeStampEx(
                    dwFlags,
                    pSubjectInfo,
                    timestampUrl,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    out signerContext
                    );
                if (hResult != 0)
                {
                    // See if we can get anything useful.
                    Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
                }
            }
            #endregion
        }
    }
