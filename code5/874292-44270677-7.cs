        public static bool UploadFile(string folder, Dictionary<string, string> Photo_Paths)
        {
            bool success = false;
            FtpWebRequest ftp_web_request = null;
            FtpWebResponse ftp_web_response = null;
            foreach (KeyValuePair<string, string> item in Photo_Paths)
            {
                string subdomain = ConfigurationManager.AppSettings["subdomain"];
                string ftp_path = @"ftp://foo.bar.com/" + folder + @"/" + item.Key;
                try
                {
                    ftp_web_request = (FtpWebRequest)WebRequest.Create(ftp_path);
                    ftp_web_request.UseBinary = true;
                    ftp_web_request.UsePassive = false;
                    ftp_web_request.EnableSsl = false;
                    ftp_web_request.Method = WebRequestMethods.Ftp.UploadFile;
                    ftp_web_request.Credentials = new NetworkCredential("username", "password");
                    try
                    {
                        MessageBox.Show(item.Value); //debug
                        byte[] buffer = File.ReadAllBytes(item.Value);
                        using (Stream file_stream = ftp_web_request.GetRequestStream())
                        {
                            file_stream.Write(buffer, 0, buffer.Length);
                        }
                        ftp_web_response = (FtpWebResponse)ftp_web_request.GetResponse();
                        if (ftp_web_response != null)
                        {
                            string ftp_response = ftp_web_response.StatusDescription;
                            string status_code = Convert.ToString(ftp_web_response.StatusCode);
                            MessageBox.Show(ftp_response + Environment.NewLine + status_code); //debug
                        }
                    }
                    catch (Exception Ex) //(WebException Ex)
                    {
                        //string status = ((FtpWebResponse)Ex.Response).StatusDescription;
                        string status = Convert.ToString(Ex);
                        MessageBox.Show("Failed upload a file." + Environment.NewLine + status); //debug
                    }
                    ftp_web_response.Close();
                    success = true;
                }
                catch (Exception Ex)
                {
                    //string status = ((FtpWebResponse)Ex.Response).StatusDescription;
                    string status = Convert.ToString(Ex);
                    if (ftp_web_response != null)
                    {
                        string ftp_response = ftp_web_response.StatusDescription;
                        string status_code = Convert.ToString(ftp_web_response.StatusCode);
                        MessageBox.Show(ftp_response + Environment.NewLine + status_code); //debug
                    }
                    MessageBox.Show("Failed upload a file." + Environment.NewLine + status); //debug
                }
            }
            return success;
        }
