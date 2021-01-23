            String1 = "";
            for (int i = 0; i < String2.Length; i++)
            {
                var charByte = System.Text.Encoding.GetEncoding(1252).GetBytes(String2.Substring(i, 1));
                AddNumber = i + 95;
                AsciiNumber = Convert.ToInt32(charByte[0]) - AddNumber;
                String1 += Convert.ToChar(AsciiNumber);
            }
