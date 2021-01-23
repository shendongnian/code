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
    
                return result.Select(list => list.ToArray()).ToArray();
            }
