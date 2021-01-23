            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                IList<PropertyInfo> properties = type.GetProperties();
                foreach (PropertyInfo pi in properties)
                {
                    if (type.IsDefined(typeof(DataElementAttribute), false))
                    {
                        // Perform Logic
                    }
                }
            }
