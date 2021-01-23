            string byteString = "";
            foreach (var chr in testString)
            {
                byteString += chr;
                if (byteString.Length == 3)
                {
                    splitBytes.Add(Convert.ToByte(byteString));
                    byteString = "";
                }
            }
            if (byteString != "")
                splitBytes.AddRange(Encoding.ASCII.GetBytes(byteString));
    using (var ms = new MemoryStream(Encoding.ASCII.GetBytes(rxstring)))
    {
        var img = System.Drawing.Image.FromStream(ms);
        //do something with image.
    }
