    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;
    namespace ConsoleApplication1
    {
        class Program
        {
            public static void AsciiToHexConversionTest()
            {
                var inputStr = "Hurrah";
                char[] values = inputStr.ToCharArray();
                List<UInt16> listOfUInt16s = new List<UInt16>();
                UInt16 mask = (UInt16)0x00FF;
                for(int i=0;i<values.Length;i+=2)
                { 
                    //This approach assumes stuffing the lower 8 bits of two chars into the upper and lower half of UInt16
                    UInt16 first = values[i];
                    UInt16 second = (UInt16)(mask & values[i+1]); //mask is for safety.  Must ensure that top byte is 0 so that | below goes ok.
                    listOfUInt16s.Add((UInt16)((first << 8) | second));
                }
                //demonstrate hexadecimal values
                Debug.Assert(listOfUInt16s[0] == 0x4875);
                Debug.Assert(listOfUInt16s[1] == 0x7272);
                Debug.Assert(listOfUInt16s[2] == 0x6168);
                //demonstrate decimal values
                Debug.Assert(listOfUInt16s[0] == 18549);
                Debug.Assert(listOfUInt16s[1] == 29298);
                Debug.Assert(listOfUInt16s[2] == 24936);
                //directly demonstrate equality of decimal and hexadecimal    representations
                Debug.Assert(0x4875 == 18549);
                Debug.Assert(0x7272 == 29298);
                Debug.Assert(0x6168 == 24936);
   
                String hexString = DecodeToHexString(listOfUInt16s);
                Debug.Assert(hexString=="487572726168");
            }
            public static string DecodeToHexString(List<UInt16> list)
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
                AsciiToHexConversionTest();
            }
        }
    }
