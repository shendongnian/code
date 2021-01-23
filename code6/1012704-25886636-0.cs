        public static Object GetInstanceFrom(AppDomain domain, string typeFullName)
        {
            Object objectInstance = null;
            var myAssembly = domain.GetAssemblies().Where(w => w.GetTypes().Select(s => s.FullName.ToUpperInvariant()).Contains(typeFullName.ToUpperInvariant())).FirstOrDefault();
            if (myAssembly != null)
            {
                var myTypeFromAssembly = myAssembly.GetTypes().Where(w => w.FullName.ToUpperInvariant() == typeFullName.ToUpperInvariant()).FirstOrDefault();
                if (myTypeFromAssembly != null)
                {
                    objectInstance = System.Activator.CreateInstance(myTypeFromAssembly);
                }
            }
            return objectInstance;
        }
