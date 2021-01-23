            List<List<string>> output = new List<List<string>>();
            foreach(var property in typeof(Test).GetProperties(
                BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.PropertyType != typeof(string)) continue;
                var getter = (Func<Test, string>)Delegate.CreateDelegate(
                    typeof(Func<Test, string>), property.GetGetMethod());
                output.Add(test.Select(getter).ToList());
            }
