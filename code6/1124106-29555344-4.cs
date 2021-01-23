    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;
    namespace ConsoleApplication1
    {
        class Program
        {
            public static ushort[] AsciiToHexConversionTest()
            {
                var inputStr = "Hurrah";
                char[] values = inputStr.ToCharArray();
                List<ushort> listOfUshorts = new List<ushort>();
                ushort mask = (ushort)0x00FF;
                for (int i = 0; i < values.Length; i += 2)
                {
                    //This approach assumes stuffing the lower 8 bits of two chars into the upper and lower half of ushort
                    ushort first = values[i];
                    ushort second = (ushort)(mask & values[i + 1]); //mask is for safety.  Must ensure that top byte is 0 so that | below goes ok.
                    listOfUshorts.Add((ushort)((first << 8) | second));
                }
                //demonstrate hexadecimal values
                Debug.Assert(listOfUshorts[0] == 0x4875);
                Debug.Assert(listOfUshorts[1] == 0x7272);
                Debug.Assert(listOfUshorts[2] == 0x6168);
                //demonstrate decimal values
                Debug.Assert(listOfUshorts[0] == 18549);
                Debug.Assert(listOfUshorts[1] == 29298);
                Debug.Assert(listOfUshorts[2] == 24936);
                //directly demonstrate equality of decimal and hexadecimal representations
                Debug.Assert(0x4875 == 18549);
                Debug.Assert(0x7272 == 29298);
                Debug.Assert(0x6168 == 24936);
                String hexString = DecodeToHexString(listOfUshorts);
                Debug.Assert(hexString == "487572726168");
                return listOfUshorts.ToArray();
            }
            public static string DecodeToHexString(List<ushort> list)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in list)
                {
                    sb.Append(string.Format("{0:X}", item));
                }
                return sb.ToString();
            }
            static void Main(string[] args)
            {
                ushort [] result = AsciiToHexConversionTest();
                StringBuilder finalOutput = new StringBuilder();
                foreach (var item in result)
                {
                    finalOutput.Append(String.Format("0x{0:X},", item));
                }
                finalOutput.Remove(finalOutput.Length - 1, 1); //Remove final comma
                Console.WriteLine(finalOutput.ToString());
                Debug.Assert(finalOutput.ToString() == "0x4875,0x7272,0x6168");
                var readKey = Console.ReadKey();
            }
        }
    }
