                // copy the xml file to isolated storage
                using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (!file.FileExists("bar.xml"))
                    {
                        StreamResourceInfo sr_en = Application.GetResourceStream(new Uri("Resources\\bar.xml", UriKind.Relative));
                        using (BinaryReader br_en = new BinaryReader(sr_en.Stream))
                        {
                            byte[] data = br_en.ReadBytes((int)sr_en.Stream.Length);
                            //Write the file.
                            using (BinaryWriter bw = new BinaryWriter(file.CreateFile("bar.xml")))
                            {
                                bw.Write(data);
                                bw.Close();
                            }
                        }
                    }
    
                    // work with file at isolatedstorage
                    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("bar.xml", FileMode.Open, file))
                    {
                        XDocument doc = XDocument.Load(stream, LoadOptions.None);
    
                        // add new node to data section
                        doc.Descendants("data").FirstOrDefault().Add(
                            new XElement("cocktail",
                                new XElement("name", "Dreamsicle"),
                                new XElement("id", 1)
                            )
                        );
                        // prevent xml file from doubling nodes
                        if (stream.CanSeek)
                            stream.Seek(0, SeekOrigin.Begin);
                        doc.Save(stream);
                    }
                }
