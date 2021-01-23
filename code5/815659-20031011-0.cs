            if (int.TryParse(integerLine, out integer) && int.TryParse(positionLine, out position) && int.TryParse(valueLine, out value)) // Try to parse the strings as integers
            {
                BitArray a = new BitArray(BitConverter.GetBytes(integer));
                a.Set(position, value == 1);
                Console.WriteLine("(n) After bit conversion = {0}", a.GetInt32());
            }
