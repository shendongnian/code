    public void Shuffle(List<int> list)
    {
        Random random = new Random();
        for (int i = 0; i < list.Count; i++)
        {
            int k = random.Next(i + 1);
            int val = list[k];
            list[k] = list[i];
            list[i] = val;
        }
    }
