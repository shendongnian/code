    BigInteger i = 1;
             i = i << 1000;
            char[] myBigInt = i.ToString().ToCharArray();
            long sum = long.Parse(myBigInt[0].ToString());
            for (int a = 0; a < myBigInt.Length - 1; a++)
            {
                sum += long.Parse(myBigInt[a + 1].ToString());
            }
            Console.WriteLine(sum);
