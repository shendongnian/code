        public B Convert<A, B>(A element) where B : A, new()
        {
            //get the interface's properties that implement both a getter and a setter
            IEnumerable<PropertyInfo> properties = typeof(A)
                .GetProperties()
                .Where(property => property.CanRead && property.CanWrite).ToList();
            //create new object
            B b = new B();
            //copy the property values to the new object
            foreach (var property in properties)
            {
                //read value
                object value = property.GetValue(element);
                //set value
                property.SetValue(b, value);
            }
            return b;
        }
