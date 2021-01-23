    public void CreateListByNonGenericType(object myObject)
            {
                object objType = myObject.GetType();
                var lst = new List<object>();
                lst.Add(myObject);
            }
