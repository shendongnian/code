                        public void sendFileToServer(String filename) {
                            var a = File.OpenRead(filename);
                            FileInfo fo = new FileInfo(filename);
                            long filesize = fo.Length;
                            // Send filename to server
                            sw.WriteLine("Filename: " + filename);
                            sw.Flush();
                            // Send filesize to server
                            sw.WriteLine("Filesize: " + filesize);
                            sw.Flush();
                            // Write file into fileBytes-Array and sends it in parts
                            Byte[] fileBytes = new Byte[1024];
                            long count = filesize;
                            while (count > 0) {
                                int recieved = a.Read(fileBytes, 0, fileBytes.Length);
                                a.Flush();
                                nws.Write(fileBytes, 0, recieved);
                                nws.Flush();
                                count -= recieved;
                            }
                            a.Close();
                            nws.Close();
                            sw.Close();
                            sr.Close();
                            clientConnection.Close();
           
                        }
