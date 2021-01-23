    using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                        {
                            ds.ReadXml(stream);
     _blockDeviceID = Convert.ToInt32(_blockData[1]);
                                ds.Tables[0].Columns.Add("ArrayLength", typeof(string));
                                 ds.Tables[0].Rows[0]["ArrayLength"] = _blockData.Length +  "";
                                // Reset the stream here to the beginning of the file!
                                
                                ds.WriteXml(stream);
    }
