    private char Grade(int marks)
    {
        Dictionary<int, char> grades = new Dictionary<int, char> { { 60, 'A' }, { 50, 'B' } };
        foreach (var item in grades)
        {
            if (marks > item.Key)
                return item.Value;
        }
        return 'C';
    }
