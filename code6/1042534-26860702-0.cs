        public void Test()
        {
            MyClass myClass = new MyClass();
            Dog dog = myClass.AddGenericComponent<Dog>();
            dog.name = "Fluffy";
            MessageBox.Show(dog.name);
            //testing the accessor - ADD a NULL CHECK!!!
            dog = myClass.GetGenericComponent<Dog>();
            dog.name = "Fluffy mod";
            MessageBox.Show(dog.name);
        }
        public class MyClass
        {
            List<Object> objects = new List<Object>();
            public T AddGenericComponent<T>() where T : class, new()
            {
                T obj = GetGenericComponent<T>();
                
                if (obj == null)
                {
                    obj = new T();
                    objects.Add(obj);
                }
                return obj;
            }
            public T GetGenericComponent<T>() where T : class, new()
            {
                var relevantObj = objects.FirstOrDefault(o => o.GetType() == typeof(T));
                if (relevantObj != null)
                {
                    return relevantObj as T;
                }
                return null;
            }
        }
        public class Dog
        {
            public string name = "";
            public Dog() { }
            public Dog(string name)
            {
                this.name = name;
            }
        }
