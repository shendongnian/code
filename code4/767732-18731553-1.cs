    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsNMEAMessageValid("$GPRMC,102957.92,A,4104.8569,N,00836.4700,W,0.000,5.822,230211,0,W,A*2B").ToString());
            Console.WriteLine(IsNMEAMessageValid("$GPRMC,102957.92,A,4104.8569,N,00836.4700,W,0.000,5.822,230211,0,W,A*1B").ToString());   // should be false, changed the checksum from 2B to 1B
            Console.WriteLine(IsTAIPMessageValid(">RPV68168+4008572-0828021400026912;ID=M123;*d<").ToString());
            Console.WriteLine(IsTAIPMessageValid(">RPV68168+4008572-0828021400026912;ID=M123;*c<").ToString());    // should be false, changed the checksum from d to c
            Console.WriteLine(IsTAIPMessageValid(">RPV54366+4001403-0828656300005512;ID=GH75;*7c<").ToString());
            Console.WriteLine(IsTAIPMessageValid(">RPV54366+4001403-0828656300005512;ID=GH75;*7b<").ToString());    // should be false, changed the checksum from 7c to 7b
            Console.ReadLine();
        }
        private static bool IsNMEAMessageValid(string sentence)
        {
            // Checksum for NMEA includes XOR on all characters between (not including) the $ and the *, including the commas...
            int checksum = Convert.ToByte(sentence[sentence.IndexOf('$') + 1]);
            for (int i = sentence.IndexOf('$') + 2; i < sentence.IndexOf('*'); i++)
            {
                checksum ^= Convert.ToByte(sentence[i]);
            }
            int givenChecksum = Convert.ToInt16(sentence.Split('*')[1], 16);
            return checksum == givenChecksum;
        }
        private static bool IsTAIPMessageValid(string sentence)
        {
            // Checksum for TAIP includes XOR on all characters starting with > and up to and including *
            int checksum = Convert.ToByte(sentence[sentence.IndexOf('>')]);
            for (int i = sentence.IndexOf('>') + 1; i < sentence.IndexOf('*') + 1; i++)
            {
                checksum ^= Convert.ToByte(sentence[i]);
            }
            char[] splitChars = { '*', '<' };
            int givenChecksum = Convert.ToInt16(sentence.Split(splitChars)[1], 16);
            return checksum == givenChecksum;
        }
    }
