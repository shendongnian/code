        public class TypeTest
        {
            public string mimimi { get; set; }
        }
    
       Type t = typeof(TypeTest);
       dynamic instanceTypeTeste = Activator.CreateInstance(t);
       instanceTipoTeste.mimimi = "test";
