    public static int PreviousQuarter(DateTime? date = null)
    {
        int[] previousQuarter = new[] {4, 4, 4, 1, 1, 1, 2, 2, 2, 3, 3, 3};
        return previousQuarter[(date ?? DateTime.Now.AddMonths(-3)).Month];
    }
