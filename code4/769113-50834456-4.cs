    int[] arr = new int[10];
    int x = 11;
    int y = 19;
    public void Update()
    {
        for (var i = 0; i < arr.Length; i++)
        {
            arr[i] = x + y;
        }
    }
