                public void recieveFile() {
                            NetworkStream nws = clientconnection.GetStream();
                            StreamReader sr = new StreamReader(nws);
                            StreamWriter sw = new StreamWriter(nws);
                            // Recieve filename
                            string filename = sr.ReadLine().Remove(0, 10);
                            // Recieve filesize
                            long filesize = Convert.ToInt64(sr.ReadLine().Remove(0, 10));
                            long count = filesize;
                            Byte[] fileBytes = new Byte[1024];
                            var a = File.OpenWrite(filename);
                            while (count > 0) {
                                int recieved = nws.Read(fileBytes, 0, fileBytes.Length);
                                nws.Flush();
                                a.Write(fileBytes, 0, recieved);
                                a.Flush();
                                count -= recieved;
                            }
                            nws.Close();
                            a.Close();
                            sr.Close();
                            sr.Close();
                            clientconnection.Close();
                        }
