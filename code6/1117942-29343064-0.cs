     public static byte[] ReadFully(Stream input)
            {
                if (input is MemoryStream)
                {
                    return ((MemoryStream)input).ToArray();
                }
                else
                {
                    return ReadFully(input);
                }
            }
