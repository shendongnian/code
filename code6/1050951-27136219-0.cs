    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    namespace wget
    {
        class Program
        {
            static bool DownloadFile(string url, string targetDirectory, out string realFilename, string defaultName = "unknown.txt")
            {
                // first set the filename to a non existing filename
                realFilename = string.Empty;
                bool succes = false;
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Method = WebRequestMethods.Http.Get;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.Headers.HasKeys())
                        {
                            /* in case no header found that is called "Location" you get your default set filename as a fallback */
                            realFilename = Path.Combine(targetDirectory, response.Headers["Location"] ?? defaultName);
                        }
                        else
                        {
                            realFilename = Path.Combine(targetDirectory, defaultName);
                        }
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            int blockSize = 8192;
                            byte[] buffer = new byte[blockSize];
                            int result;
                            if (!Directory.Exists(targetDirectory))
                            {
                                Directory.CreateDirectory(targetDirectory);
                            }
                            using (FileStream targetStream = new FileStream(realFilename, FileMode.Create, FileAccess.Write))
                            {
                                do
                                {
                                    result = responseStream.Read(buffer, 0, buffer.Length);
                                    targetStream.Write(buffer, 0, result);
                                } while (result > 0);
                            }
                        }
                    }
                    succes = true;
                }
                catch (WebException wex)
                {
                    if (wex.Response != null)
                    {
                        wex.Response.Close();
                    }
                    Console.WriteLine("WebException occured: {0}", wex.Message);
                }
                catch (FileNotFoundException fnfe)
                {
                    Console.WriteLine("FileNotFoundException occured: {0} not found! {1}", fnfe.FileName, fnfe.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occured: {0}", ex.Message);
                }
                return succes;
            }
            static void Main(string[] args)
            {
                string filename;
                if (DownloadFile("http://www.google.com", Environment.CurrentDirectory, out filename))
                {
                    Console.WriteLine("Saved file to {0}", filename);
                }
                else
                {
                    Console.WriteLine("Couldn't download file!");
                }
                Console.ReadLine();
            }
        }
    }
