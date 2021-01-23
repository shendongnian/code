       private void button1_Click(object sender, EventArgs e)
            {
    
    string input= "060201080808040602040909080909003583150369840500";
    SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                byte[] hash = sha1.ComputeHash(ConvertHexStringToByteArray(input));
                string delimitedHexHash = BitConverter.ToString(hash);
                string hexHash = delimitedHexHash.Replace("-", "");
    
               
                MessageBox.Show(hexHash); 
            }
    
            public static byte[] ConvertHexStringToByteArray(string hexString)
            {
                if (hexString.Length % 2 != 0)
                {
                    throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
                }
    
                byte[] HexAsBytes = new byte[hexString.Length / 2];
                for (int index = 0; index < HexAsBytes.Length; index++)
                {
                    string byteValue = hexString.Substring(index * 2, 2);
                    HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                }
    
                return HexAsBytes;
            }
    
       
