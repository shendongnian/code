    public void Update(int[] arr, int x, int y)
    {
        var temp = x + y;
        var length = arr.Length;
        for (var i = 0; i < length; i++)
        {
            arr[i] = temp;
        }
    }
