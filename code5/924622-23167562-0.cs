                string myString = "abc";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(myString);
            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(BitConverter.GetBytes(buffer.Length), 0, 4);
                ms.Write(buffer, 0, buffer.Length);
                //... rest of code...
            }
