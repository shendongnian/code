                int length = (int)b.BaseStream.Length;
                byte[] allData = b.ReadBytes(length);
 
                using (BinaryWriter w = new BinaryWriter(File.Open("New File Path", FileMode.Create)))
                {
 
                    for (int i = 0; i < length; i++)
                    {
                        w.Write(allData[i]);
 
                    }
 
                }
            }
