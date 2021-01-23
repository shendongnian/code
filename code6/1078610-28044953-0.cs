    static readonly Random Rand = new Random();
    private const string Alpha = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ";
     public static string GenerateAlphaString(int size)
            {
                var chars = new char[size];
                for (int i = 0; i < size; i++)
                {
                    chars[i] = Alpha[Rand.Next(Alpha.Length)];
                }
                return new string(chars);
            }
