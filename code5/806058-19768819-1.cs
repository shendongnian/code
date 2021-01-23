     var t = typeof(MyClass);
            var l = t.GetMethods();
            foreach (var item in l)
            {
                if (item.GetMethodBody() == null && item.IsStatic)
                {
                    // Method is Extern
                }
            }
