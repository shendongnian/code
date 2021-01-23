        private string Serialize(MyData data)
        {
            XmlSerializer ser = new XmlSerializer(typeof(MyData));
            // Using a MemoryStream to store the serialized string as a byte array, 
            // which is "encoding-agnostic"
            using (MemoryStream ms = new MemoryStream())
                // Few options here, but remember to use a signature that allows you to 
                // specify the encoding  
                using (XmlTextWriter tw = new XmlTextWriter(ms, Encoding.UTF8)) 
                {
                    tw.Formatting = Formatting.Indented;
                    ser.Serialize(tw, data);
                    // Now we get the serialized data as a string in the desired encoding
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
        }
