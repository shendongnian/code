           Person addperson = new Person();
           PropertyInfo[] props = addperson.GetType().GetProperties();
            foreach(PropertyInfo prop in props)
            {
                  Console.WriteLine("Please enter " + prop.Name.ToString());
                  prop.SetValue(addperson, Console.ReadLine(), null);
            }
