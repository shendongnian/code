    static void Main(string[] args)
        {
            var xtr = new XmlTextReader("");
            xtr.Normalization = false;
            while (xtr.Read())
            {
                if(xtr.IsStartElement("Row")) // My xml doc contains many row elements
                {
                    var fields = new string[6];
                    while(xtr.Read())
                    {
                        for (int i = 0; i < 6; i++) // I know my xml only has six child elements per row
                        {
                            while(!xtr.IsStartElement())
                            {
                                xtr.Read(); // We're not interested in hitting the end elements
                            }
                            if(i == 1) // I know my special characters are in the second child element of my row
                            {
                                var charBuff = new char[255];
                                xtr.ReadChars(charBuff, 0, 255); // I know there will be a maximum of 255 characters
                                fields[i] = new string(charBuff);
                            }
                            else
                            {
                                fields[i] = xtr.ReadElementContentAsString();
                            }
                        }
                    }
                }
            }
        }
