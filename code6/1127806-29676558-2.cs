        Public YourConcreteClass
        {
        Private IModelDBContext ModelDB; //Initiate an instance that you will use .
        
    
    //DI by constructor
    public YourConcreteClass(IModelDBContext mDB)
            {
        ModelDB=mDB;
    
            }
    //in the rest of your code you call ModelDB that has access to all of the methods and attributes you might need
    
        }
