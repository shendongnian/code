    public IEnumerable<MyData> Load(string parm1, int parm2)
    {
        _MyData = _dbContext.MyData.Where(m => m.Parm1 == parm1 && m.Parm2 == parm2);
        foreach(MyData mydata in _MyData)
        {
            if(mydata.Parm2 == 1)
            {
                mydata.Parm1 = "Some value";
            }
            yield return myData;
        }
    }
