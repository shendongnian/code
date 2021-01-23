           System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
            // unicode string:
            string unicodeStr = "étext";
            // Convert string to utf-8 bytes to transport 
            byte[] byteBuffUtf8 = System.Text.Encoding.UTF8.GetBytes(unicodeStr);
            // Convert back utf-8 to display ready string.
            string myUnicode = System.Text.Encoding.UTF8.GetString(byteBuffUtf8);
            MessageBox.Show(myUnicode);
