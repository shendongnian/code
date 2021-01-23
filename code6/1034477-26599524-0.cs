    void DoWork(IEnumerable items, Type type)
        {
            // instance of object you want to call
            var thirdPartyObject = new ThirdPartyObject();
            // create a list with type "type"
            var typeOfList = typeof(List<>).MakeGenericType(type);
            // create an instance of the list and set items 
            // as constructor parameter
            var listInstance = Activator.CreateInstance(listOfTypes, items);
            // call the 3. party method via reflection, make it generic and
            // provide our list instance as parameter
            thirdPartyObject.GetType().GetMethod("ThirdPartyMethod")
                .MakeGenericMethod(type)
                .Invoke(thirdPartyObject, new []{listInstance});            
        }
 
