            int a = 27;//int= 8byte equal to 32 bit
            string binary = "";
            for (int i = 0; i < 32; i++)
            {             
                if ((a&1)==0)//if a's least significant bit is 0 ,add 0 to str
                {
                    binary = "0" + binary;
                }
                else//if a's least significant bit is 1 ,add 1 to str
                {
                    binary = "1" + binary;
                }
                a = a >> 1;//shift the bits left to right and delete lsb
                //we are doing it for 32 times because integer have 32 bit.
            }
            Console.WriteLine("Integer to Binary= "+binary);
         //Now you can operate the string(binary) however you want.
          binary = binary.Remove(binary.Length-4,1);//remove 4st bit from str
