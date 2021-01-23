            // -7 produces "1 10000001 11000000000000000000000"
            static string FloatToBinary(float f)
            {
                StringBuilder sb = new StringBuilder();
                Byte[] ba = BitConverter.GetBytes(f);
                foreach (Byte b in ba)
                    for (int i = 0; i < 8; i++)
                    {
                        sb.Insert(0,((b>>i) & 1) == 1 ? "1" : "0");
                    }
                string s = sb.ToString();
                string r = s.Substring(0, 1) + " " + s.Substring(1, 8) + " " + s.Substring(9); //sign exponent mantissa
                return r;
            }
