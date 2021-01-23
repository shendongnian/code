    List<int[]> arrayList = new List<int[]>();
    public void Add(int Id , int Quantity )
    {
        int[] buying = new int[] { Id, Quantity };
        //AddTo(buying);
        arrayList.Add(buying);
    }
