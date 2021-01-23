            A obj1 = new A();
            A obj2 = new A();
            obj1.aField = "aaa";
            var propInfo = obj1.GetType().GetProperties();
            foreach (var item in propInfo)
            {
                obj2.GetType().GetProperty(item.Name).SetValue(obj2, item.GetValue(obj1, null), null);
            }
