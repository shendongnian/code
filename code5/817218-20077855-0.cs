    public static class HexAdder
    {
        private static UInt32 num1 = 0, num2 = 0;
        private static void ParseString(string stringtoadd)
        {
            string[] temp = {"",""};
            try
            {
                temp = stringtoadd.Split(" +".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                num1 = Convert.ToUInt32(temp[0], 16);
                num2 = Convert.ToUInt32(temp[1], 16);
            }
            catch(Exception e)
            {
                
                MessageBox.Show("Invalid String Format\n- Added String = " + stringtoadd + "\n- First Part = " + temp[0] + "\n- Second Part = " + temp[1]);
            }
        }
        public static UInt32 AddedToUint32(string stringtoadd)
        {
            ParseString(stringtoadd);
            return num1 + num2;
        }
    }
