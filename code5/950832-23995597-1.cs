    public static byte[][] Split(byte[] arr, byte keyword)
            {
                var result = new List<List<byte>>();
    
                var piece = new List<byte>();
    
                foreach (var b in arr)
                {
                    if (b != keyword)
                    {
                        piece.Add(b);
                    }
                    else
                    {
                        result.Add(piece);
                        piece = new List<byte>();
                    }
                }
    
                result.Add(piece);
    
                return ToArrayOfArray(result);
            }
    public static T[][] ToArrayOfArray<T>(List<List<T>> list)
            {
                var res = new T[list.Count][];
    
                for (int i = 0; i < list.Count; i++)
                {
                    res[i] = list[i].ToArray();
                }
    
                return res;
            }
