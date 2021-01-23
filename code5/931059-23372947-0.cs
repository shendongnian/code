        public void Read(string name, string info, Type type)
        {
            ConstructorInfo ctor = type.GetConstructor(System.Type.EmptyTypes);
            if (ctor != null)
            {
                dynamic temp = ctor.Invoke(null);
                database.retrieve(name, info, out temp);
                Debug.Log(temp.ToString());
            }
        }
