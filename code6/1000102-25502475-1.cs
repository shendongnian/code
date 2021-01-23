    public void GenericMethod<T>(out Result result) where T : new(), BaseClass
    {
         T t = new T();
         Handle(t, result);
    }
    private void Handle(BaseClass arg1, out Result result)
    {
        //do something need to be done for BaseClass;
    }
