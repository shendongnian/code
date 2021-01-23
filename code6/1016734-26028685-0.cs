    void DoSomethingWithSomeTable(int day, int month, int year)
    {
        var query = from t in SomeTable
                    where t.Time.Date.Equals(new DateTime(year, month, day))
                    select t;
    }
