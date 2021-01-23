            using (MemoryStream ms1 = new MemoryStream())
            {
                using (FileStream file = new FileStream("document.txt", FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[file.Length];
                    file.Read(bytes, 0, (int)file.Length);
                    ms1.Write(bytes, 0, (int)file.Length);
                }
            }
