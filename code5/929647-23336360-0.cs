            string lastTag = "</ArrayOfAddressInfo>";
            string newNode = "\r\n<AddressInfo>\r\n<Level1/>\r\n</AddressInfo>";
            int offset = 5;
            using (FileStream xmlstream = new FileStream(
                @"test.xml",
                FileMode.Open,
                FileAccess.ReadWrite,
                FileShare.None))
            {
                // Get to the appx position, assumes the last tag is the
                // last thing in the file.  Adjust the offset accordingly
                // for your needs
                xmlstream.Seek(-(lastTag.Length + offset), SeekOrigin.End);
                // Check - are we at the >
                while (xmlstream.ReadByte() != '>')
                    ;
                // Write our bit of xml
                xmlstream.Write(
                    Encoding.ASCII.GetBytes(newNode),
                    0, newNode.Length);
                // Rewrite the last tag
                xmlstream.Write(
                    Encoding.ASCII.GetBytes("\r\n" + lastTag + "\r\n"),
                    0, lastTag.Length + 2);
                xmlstream.Close();
            }
