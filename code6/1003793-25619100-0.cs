    public interface IDoesSomething
    {
         private void Do();
    } 
    
    public void SomeMethod(IDoesSomething some) 
    {
        some.????? // <---- what? the object doesn't have public members!
    }
