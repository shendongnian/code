       private int[] generatePermutation(int size, int seed) 
       {
            var permutation = new int[size];
            Rnd random = new Rnd(seed);
            List<int> permList = new List<int>(size);
            for (int i = 0; i < size; i++) permList.Add(i);
            for (int i = 0; i < size; i++)
            {
                int index = random.Next(0, permList.Count);
                permutation[i] = permList[index];
                permList.RemoveAt(index);
            }
            return permutation;
        }
