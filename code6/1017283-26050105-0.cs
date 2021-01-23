      // Number of Dictionary hash buckets found here:
      // http://stackoverflow.com/questions/24366444/how-many-hash-buckets-does-a-net-dictionary-use
      const int CNumberHashBuckets = 4999559;
      
      static void Main(string[] args)
      {
         Random randomNumberGenerator = new Random();
         int[] dictionaryBuckets1 = new int[CNumberHashBuckets];
         int[] dictionaryBuckets2 = new int[CNumberHashBuckets];
         
         for (int i = 0; i < 5000000; i++)
         {
            ulong randomKey = (ulong)(randomNumberGenerator.NextDouble() * 0x0FFFFFFFFFFF);
            int simpleHash = randomKey.GetHashCode();
            BumpHashBucket(dictionaryBuckets1, simpleHash);
            int superHash = ((int)(randomKey >> 12)).GetHashCode() ^ ((int)randomKey).GetHashCode();
            BumpHashBucket(dictionaryBuckets2, superHash);
         }
         int collisions1 = ComputeCollisions(dictionaryBuckets1);
         int collisions2 = ComputeCollisions(dictionaryBuckets2);
      }
      private static void BumpHashBucket(int[] dictionaryBuckets, int hashedKey)
      {
         int bucketIndex = (int)((uint)hashedKey % CNumberHashBuckets);
         dictionaryBuckets[bucketIndex]++;
      }
      private static int ComputeCollisions(int[] dictionaryBuckets)
      {
         int i = 0;
         foreach (int dictionaryBucket in dictionaryBuckets)
            i += Math.Max(dictionaryBucket - 1, 0);
         return i;
      }
