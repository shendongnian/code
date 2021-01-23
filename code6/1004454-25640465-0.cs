        public object GetAnimal(Animal animal)
        {
            var ns = typeof(Animal).Namespace; //or your classes namespace if different
            var typeName = ns + "." + animal.ToString();
            return Activator.CreateInstance(Type.GetType(typeName));
        }
