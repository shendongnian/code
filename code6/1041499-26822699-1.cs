        public CreateObject(string className, object[] parameters)
        {
            this.className = className;
            try
            {
                if (parameters.Length == 1 && parameters[0] == "") // no parameters
                {
                    Activator.CreateInstance(Type.GetType(className)); 
                }
                else
                {
                    Activator.CreateInstance(Type.GetType(className), parameters);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
            }
        }
