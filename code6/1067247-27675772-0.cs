        class MyClass
        {
            public string Text1 { get; set; }
            public string Text2 { get; set; }
            public string Text3 { get; set; }
            public int Int1 { get; set; }
        }
        public static void Test()
        {
            var obj1 = new MyClass {Text1 = "Test1", Text2 = "Test2", Text3 = "Test3", Int1 = 0};
            var obj2 = new MyClass {Text3 = "Another Test", Int1 = 1};
            var obj3 = MergeObjects(obj1, obj2);
        }
        public static T MergeObjects<T>(T obj1, T obj2)
        {
            var objResult = Activator.CreateInstance(typeof(T));
            var allProperties = typeof(MyClass).GetProperties().Where(x => x.CanRead && x.CanWrite);
            foreach (var pi in allProperties)
            {
                object defaultValue;
                if (pi.PropertyType.IsValueType)
                {
                    defaultValue = Activator.CreateInstance(pi.PropertyType);
                }
                else
                {
                    defaultValue = null;
                }
                var value = pi.GetValue(obj2, null);
                
                if (value != defaultValue)
                {
                    pi.SetValue(objResult, value, null);
                }
                else
                {
                    value = pi.GetValue(obj1, null);
                    if (value != defaultValue)
                    {
                        pi.SetValue(objResult, value, null);
                    }
                }
            }
            return (T)objResult;
        }
