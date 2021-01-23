    public void SomeCall<T>(List<T> list) where T: BaseClass
    {
       foreach(T item in list)
       {
           // Assumes BaseClass defines method doSomething
           item.doSomething(....);
       }
    }
