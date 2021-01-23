        public string CalculateFileHashTotal(string fileLocation)
                {
                    using (var md5 = MD5.Create())
                    {
                        using (var stream = File.OpenRead(fileLocation))
                        {
                            byte[] b = md5.ComputeHash(stream);
                            stream.Close();
                            return BitConverter.ToString(B).Replace("-", "").ToLower();
                        }
                    }
                }
