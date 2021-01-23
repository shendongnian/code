    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                ushort[] result = AsciiToHexConversionTest();
                String outputAsHexString = DecodeToHexString(result);
                Debug.Assert(outputAsHexString == "0x4875,0x7272,0x6168");
                Console.WriteLine(outputAsHexString);
                var readKey = Console.ReadKey();
            }
            public static ushort[] AsciiToHexConversionTest()
            {
                var inputStr = "Hurrah";
                char[] values = inputStr.ToCharArray();
                List<ushort> listOfUshorts = new List<ushort>();
                ushort mask = (ushort)0x00FF;
                for (int i = 0; i < values.Length; i += 2)
                {
                    //This approach assumes stuffing the lower 8 bits of two chars into the upper and lower half of a ushort
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
                return listOfUshorts.ToArray();
            }
            public static string DecodeToHexString(ushort[] list)
            {
                StringBuilder finalOutput = new StringBuilder();
                foreach (var item in list)
                {
                    finalOutput.Append(String.Format("0x{0:X},", item));
                }
                finalOutput.Remove(finalOutput.Length - 1, 1); //Remove final comma
                return finalOutput.ToString();
            }
        }
    }
