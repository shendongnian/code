    public void CreateListByNonGenericType(object myObject)
    {
        Type objType = myObject.GetType();
        Type listType = typeof(List<>).MakeGenericType(objType);
        //We can not use here generic version of the interface, as we
        // do not know the type at compile time, so we use the non generic 
        // interface IList which will enable us to Add and Remove elements from
        // the collection
        IList lst = (IList)Activator.CreateInstance(listType);
    }
