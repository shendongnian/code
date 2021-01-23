        public virtual IQueryable<T> GetAll()
        {
            //Methods retreives an array of objects.
            var collectionFromWcfService = _getAllFromWcf.Invoke(_rawServiceObject, new object[] {});
            //Says that this is an array
            var typeOfArray = collectionFromWcfService.GetType();
            //This is the type of object in the array
            var elementTypeInArray = typeOfArray.GetElementType();
            MethodInfo method = typeof(Extensions).GetMethod("MapCollectionWithoutExtension");
            MethodInfo generic = method.MakeGenericMethod(elementTypeInArray,typeof(T));
            var convertedListOfObjects = (List<T>)generic.Invoke(this, new []{ collectionFromWcfService });
            return convertedListOfObjects.AsQueryable(); 
        }
