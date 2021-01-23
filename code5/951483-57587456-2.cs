    public static Tuple<List<string>, List<string>> GenerateUniqueList(int count)
        {
            uniqueHashTable = new Hashtable();
            nonUniqueList = new List<string>();
            uniqueList = new List<string>();
            for (int i = 0; i < count; i++)
            {
                isUniqueGenerated = false;
                while (!isUniqueGenerated)
                {
                    uniqueStr = GetUniqueKey();
                    try
                    {
                        uniqueHashTable.Add(uniqueStr, "");
                        isUniqueGenerated = true;
                    }
                    catch (Exception ex)
                    {
                        nonUniqueList.Add(uniqueStr);
                        // Non-unique generated
                    }
                }
            }
            uniqueList = uniqueHashTable.Keys.Cast<string>().ToList();
            return new Tuple<List<string>, List<string>>(uniqueList, nonUniqueList);
        }
        public static string GetUniqueKey()
        {
            int size = 7;
            char[] chars = new char[62];
            string a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            byte[] data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
                result.Append(chars[b % (chars.Length - 1)]);
            return Convert.ToString(result);
        }
Whole Console Application Code below;
    
    class Program
    {
        static string uniqueStr;
        static Stopwatch stopwatch;
        static bool isUniqueGenerated;
        static Hashtable uniqueHashTable;
        static List<string> uniqueList;
        static List<string> nonUniqueList;
        static Tuple<List<string>, List<string>> generatedTuple;
        static void Main(string[] args)
        {
            int i = 0, y = 0, count = 100000;
            while (i < 10 && y < 4)
            {
                stopwatch = new Stopwatch();
                stopwatch.Start();
                generatedTuple = GenerateUniqueList(count);
                stopwatch.Stop();
                Console.WriteLine("Time elapsed: {0} --- {1} Unique  --- {2} nonUnique",
                    stopwatch.Elapsed,
                    generatedTuple.Item1.Count().ToFormattedInt(),
                    generatedTuple.Item2.Count().ToFormattedInt());
                i++;
                if (i == 9)
                {
                    Console.WriteLine(string.Empty);
                    y++;
                    count *= 10;
                    i = 0;
                }
            }
            Console.ReadLine();
        }
        public static Tuple<List<string>, List<string>> GenerateUniqueList(int count)
        {
            uniqueHashTable = new Hashtable();
            nonUniqueList = new List<string>();
            uniqueList = new List<string>();
            for (int i = 0; i < count; i++)
            {
                isUniqueGenerated = false;
                while (!isUniqueGenerated)
                {
                    uniqueStr = GetUniqueKey();
                    try
                    {
                        uniqueHashTable.Add(uniqueStr, "");
                        isUniqueGenerated = true;
                    }
                    catch (Exception ex)
                    {
                        nonUniqueList.Add(uniqueStr);
                        // Non-unique generated
                    }
                }
            }
            uniqueList = uniqueHashTable.Keys.Cast<string>().ToList();
            return new Tuple<List<string>, List<string>>(uniqueList, nonUniqueList);
        }
        public static string GetUniqueKey()
        {
            int size = 7;
            char[] chars = new char[62];
            string a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            byte[] data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
                result.Append(chars[b % (chars.Length - 1)]);
            return Convert.ToString(result);
        }
    }
    public static class IntExtensions
    {
        public static string ToFormattedInt(this int value)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:0,0}", value);
        }
    }
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.collections.hashtable?view=netframework-4.8
  [2]: https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rngcryptoserviceprovider?view=netframework-4.8
  [3]: https://screenshot.net/1nlx5im
  [4]: https://nipulparikh.wordpress.com/2015/04/15/generating-unique-key-in-net-using-rngcryptoserviceprovider/
