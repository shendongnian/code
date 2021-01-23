    static void Main(string[] args)
    {
        //simulation: creat 10 MyObjects
        List<MyObject> lst = new List<MyObject>();
        for (int i = 0; i < 10; i++)
        {
            MyObject m = new MyObject();
            //example of setting condition
            m.setCondition(MyObject.Conditions.C1, true);
            lst.Add(m);
        }
        //calculate stat
        var resultCount = new Dictionary<string, int>(); //conditionResult, count
        foreach (MyObject m in lst)
        {
            int c;
            if (resultCount.TryGetValue(m.ToString(), out c))
            {
                resultCount[m.ToString()] += 1;
            }
            else
            {
                resultCount.Add(m.ToString(), 1);
            }
        }
        //print stat
        foreach(KeyValuePair<string, int> entry in resultCount){
            Debug.WriteLine("probability for conditoin={0} is {1}", entry.Key, (double)entry.Value / lst.Count);
        }
    }
