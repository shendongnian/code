    byte[] input = Encoding.ASCII.GetBytes("bangalore");
    var known_result = new byte[] { 30, 20, 21, 92, 20, 80, 32, 31, 02 };
    var computed_mask = new byte[input.Length];
    
    for (var i = 0; i < input.Length; i++)
    {
        computed_mask[i] = (byte)(known_result[i] ^ input[i]);
    }
                
    byte[] test = Encoding.ASCII.GetBytes("bangalore");
    for (var i = 0; i < test.Length; i++)
    {
        test[i] ^= computed_mask[i];
    }
    Console.WriteLine(string.Join(",", test));
