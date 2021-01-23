    private int GetRandomInt(int min, int max)
    {
         int num = Random.Range(min, max);
         while(usedIndexes.Contains(num))
         {
              num = Random.Range(min, max);
         }
         return num;
    }
