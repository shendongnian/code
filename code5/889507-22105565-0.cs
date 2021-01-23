            using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                // Create the streams used for encryption. 
                using (Stream msEncrypt = new FileStream(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString()) + @"\itemlist.xml"))
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // Create a new XmlSerializer instance with the type of the test class
                            XmlSerializer SerializerObj = new XmlSerializer(typeof(List<ItemsUnderControlObject>));
                            // Create a new file stream to write the serialized object to a file
                            SerializerObj.Serialize(swEncrypt, MyGlobals.ListOfItemsToControl);
                        }
                    }
                }
            }
