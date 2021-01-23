    public void MyFunction(List<string> methodlist)
    {
        foreach (string methodName in methodlist)
        {
            this.GetType().GetMethod(methodName).Invoke(this, null);
        }
