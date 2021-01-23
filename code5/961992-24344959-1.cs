        public IBsonSerializer GetSerializer(Type type)
        {
            if (type == typeof(Dependncies)
            {
                return new DependenciesBsonSerializer ();
            }
            return null;
        }
    }
