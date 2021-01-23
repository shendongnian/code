    // write string out
    byte[] data = Encoding.UTF8.GetBytes(xmlString);
    
    using (StreamWriter writer = File.CreateText(fullPath + "Module" + i + "D" + historicDataCount +  ".bin"))
        using (ToBase64Transform transformation = new ToBase64Transform())
        {                    
            byte[] buffer = new byte[transformation.OutputBlockSize];
            int i = 0;    
            while (data.Length - i > transformation.InputBlockSize)
            {
                transformation.TransformBlock(data, i, data.Length - i, buffer, 0);
                i += transformation.InputBlockSize;
                writer.Write(Encoding.UTF8.GetString(buffer));
            }
    
            // final block
            buffer = transformation.TransformFinalBlock(data, i, data.Length - i);
            writer.Write(Encoding.UTF8.GetString(buffer));
        }
