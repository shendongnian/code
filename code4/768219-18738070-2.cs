    public void DoSomethingImportant(string foo)
    {
        if (someCondition)
        {
            DoThisOneWay(foo);
        }
        else
        {
            DoThisDifferently(foo);
        }
    }
    protected void DoThisOneWay(string foo) {}
    protected void DoThisDifferently(string foo) {}
