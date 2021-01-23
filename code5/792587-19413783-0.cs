    IList GetListOfListsOfTypes(Type[] types)
    {
        IList<IList> listOfLists = new List<IList>();
    
        foreach (Type t in types)
        {
    		Type requestedTypeDefinition = typeof(List<>);
    		Type genericType = requestedTypeDefinition.MakeGenericType(t);
            IList newList = (IList)Activator.CreateInstance(genericType);
            listOfLists.Add(newList);
        }
    
        return listOfLists;
    }
