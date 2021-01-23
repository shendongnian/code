        public static void BootstrapStructureMap()
        {
            // Initialize the static ObjectFactory container
            ObjectFactory.Initialize(x =>
            {
                x.ForRequestedType<iNTERFACE>().TheDefaultIsConcreteType<ContreteClass>();
            });
        }
    }
