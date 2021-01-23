        private string ToBinary()
        {
            FileStream stream = File.OpenRead(@"c:\image1.jpg"
            var sb = new StringBuilder();
            int b = 0;
            while ((b = stream.ReadByte()) > -1)
            {
                sb.Append(Convert.ToString(b, 2));
            }
            return sb.ToString();
        }
