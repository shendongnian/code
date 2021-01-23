    public void OtherMethod(Action method)
    {
       MessageBox.Show("I am raised first.");
       string methodname = method.Method.Name;
       method.Invoke();
    }
    public void SomeMethod()
    {
        some code ...
    }
