    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Net;
    using System.Text;
    namespace DesktopApp
    {
        public class ExtendedWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest w = base.GetWebRequest(uri);
                w.Timeout = 60 * 60 * 1000;
                return w;
            }
            private byte[] GZipBytes(string data)
            {
                //Transform string into byte[]  
                byte[] ret = null;
                using (System.IO.MemoryStream outputStream = new System.IO.MemoryStream())
                {
                    using (GZipStream gzip = new GZipStream(outputStream, System.IO.Compression.CompressionMode.Compress))
                    {
                        //write to gzipper
                        StreamWriter writer = new StreamWriter(gzip);
                        writer.Write(data);
                        writer.Flush();
                        //write to output stream
                        gzip.Flush();
                        gzip.Close();
                        ret = outputStream.ToArray();
                    }
                }
                return ret;
            }
            /// <summary>
            /// Overriden method using GZip compressed data upload.
            /// </summary>
            /// <param name="address">Remote server address.</param>
            /// <param name="data">String data.</param>
            /// <returns>Server response string.</returns>
            public new string UploadString(string address, string data)
            {
                string ret = null;
                byte[] bytes = GZipBytes(data);
                this.Headers.Add("content-encoding", "gzip");
                bytes = base.UploadData(address, bytes);
                ret = System.Text.Encoding.UTF8.GetString(bytes);
                return ret;
            }
            /// <summary>
            /// Overriden method using GZip compressed data upload.
            /// </summary>
            /// <param name="address">Remote server URI.</param>
            /// <param name="data">String data.</param>
            /// <returns>Server response string.</returns>
            public new string UploadString(Uri address, string data)
            {
                string ret = null;
                byte[] bytes = GZipBytes(data);
                this.Headers.Add("content-encoding", "gzip");
                bytes = base.UploadData(address, bytes);
                ret = System.Text.Encoding.UTF8.GetString(bytes);
                return ret;
            }
            /// <summary>
            /// Overriden method using GZip compressed data upload.
            /// </summary>
            /// <param name="address">Remote server address.</param>
            /// <param name="method">HTTP method (e.g. POST, PUT, DELETE, GET).</param>
            /// <param name="data">String data.</param>
            /// <returns>Server response string.</returns>
            public new string UploadString(string address, string method, string data)
            {
                string ret = null;
                byte[] bytes = GZipBytes(data);
                this.Headers.Add("content-encoding", "gzip");
                bytes = base.UploadData(address, method,bytes);
                ret = System.Text.Encoding.UTF8.GetString(bytes);
                return ret;
            }
            /// <summary>
            /// Overriden method using GZip compressed data upload.
            /// </summary>
            /// <param name="address">Remote server URI.</param>
            /// <param name="method">HTTP method (e.g. POST, PUT, DELETE, GET).</param>
            /// <param name="data">String data.</param>
            /// <returns>Server response string.</returns>
            public new string UploadString(Uri address, string method, string data)
            {
                string ret = null;
                byte[] bytes = GZipBytes(data);
                this.Headers.Add("content-encoding", "gzip");
                bytes = base.UploadData(address, method, bytes);
                ret = System.Text.Encoding.UTF8.GetString(bytes);
                return ret;
            }
        }
    }
