            int a = 27;//int= 8byte equal to 32 bit
            string binary = "";
            for (int i = 0; i < 32; i++)
            {             
                if ((a&1)==0)
                {
                    binary = "0" + binary;
                }
                else
                {
                    binary = "1" + binary;
                }
                a = a >> 1;
            }
            Console.WriteLine("Integer to Binary= "+binary);
