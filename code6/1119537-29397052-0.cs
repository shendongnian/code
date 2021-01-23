    public void UpdateValueCollection(ref IList<Test> lstTest)
    {
       IList<Test> check = new List<Test>();
       check.Add(new Test(){ Value = 100});
       lstTest = check;
    }
