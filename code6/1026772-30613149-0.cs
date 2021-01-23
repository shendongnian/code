    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    
    using System.Web;
    using System.Security.Cryptography.X509Certificates;
    
    namespace HHAFSGoogle
    {
        static class GoogleSigner
        {
            private static string hashAlgo = "SHA256";
            public static string ServiceAccountEmail
            {
                get
                {
                    return "XXXXXXXXXXXXX-YYYYYYYYYYYYYYYYYYYYYYYY@developer.gserviceaccount.com";
                }
            }
    
            public static string GoogleSecreat
            {
                get
                {
                    return "notasecret";
                }
            }
    
            public static string GoogleBucketDir
            {
                get
                {
                    return "MyBucketDirectory";
                }
            }
    
            public static string GoogleBucketName
            {
                get
                {
                    return "MyBucket";
                }
            }
    
            public static string CertiFilelocation
            {
                get
                {
                    return System.Web.HttpContext.Current.Server.MapPath("p12file.p12");
                }
            }
    
            /// <summary>
            /// Get URL signature
            /// </summary>
            /// <param name="base64EncryptedData"></param>
            /// <param name="certiFilelocation"></param>
            /// <returns></returns>
            public static string GetSignature(string base64EncryptedData, string certiFilelocation)
            {
                X509Certificate2 certificate = new X509Certificate2(certiFilelocation, GoogleSecreat, X509KeyStorageFlags.Exportable);
    
                RSACryptoServiceProvider csp = (RSACryptoServiceProvider)certificate.PrivateKey;
    
                RSACryptoServiceProvider privateKey1 = new RSACryptoServiceProvider();
                privateKey1.ImportParameters(csp.ExportParameters(true));
    
                csp.ImportParameters(privateKey1.ExportParameters(true));
    
                byte[] data = Encoding.UTF8.GetBytes(base64EncryptedData.Replace("\r", ""));
    
                byte[] signature = privateKey1.SignData(data, hashAlgo);
    
                bool isValid = privateKey1.VerifyData(data, hashAlgo, signature);
    
                if (isValid)
                {
                    return Convert.ToBase64String(signature);
                }
                else
                {
                    return string.Empty;
                }
            }
    
            /// <summary>
            /// Get signed URL by Signature
            /// </summary>
            /// <param name="fileName"></param>
            /// <param name="method"></param>
            /// <param name="content_type"></param>
            /// <param name="duration"></param>
            /// <returns></returns>
            public static string GetSignedURL(string fileName, string method = "GET", string content_type = "", int duration = 10)
            {
                TimeSpan span = (DateTime.UtcNow.AddMinutes(10) - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
                var expires = Math.Round(span.TotalSeconds, 0);
    
                // Encode filename, so URL characters like %20 for space could be handled properly in signature
                fileName = HttpUtility.UrlPathEncode(fileName);
    
                // Generate a string to sign
                StringBuilder sbFileParam = new StringBuilder();
                sbFileParam.AppendLine(method);  //Could be GET, PUT, DELETE, POST
                //	/* Content-MD5 */ "\n" .
                sbFileParam.AppendLine();
                sbFileParam.AppendLine(content_type);	// Type of content you would upload e.g. image/jpeg
                sbFileParam.AppendLine(expires.ToString());		// Time when link should expire and shouldn't work longer
                sbFileParam.Append("/" + GoogleBucketName + "/" + fileName);
    
                var signature = System.Web.HttpContext.Current.Server.UrlEncode(GetSignature(sbFileParam.ToString(), CertiFilelocation));
    
                return ("https://storage.googleapis.com/MyBucket/" + fileName +
                            "?response-content-disposition=attachment;&GoogleAccessId=" + ServiceAccountEmail +
                            "&Expires=" + expires + "&Signature=" + signature);
            }
        }
    }
