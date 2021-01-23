    public void Run()
    {
        if ( right - left == 1 )
        {
            Answer = arr[left];
        }
        else
        {
            Answer = new bool[] { true, false }
                .AsParallel()
                .Sum(isLeft =>
                    {
                        SumRange sumRange = isLeft
                            ? new SumRange(arr, left, (left + right) / 2)
                            : new SumRange(arr, (left + right) / 2, right);
                        sumRange.Run();
                        return sumRange.Answer;
                    });
        }
    }
