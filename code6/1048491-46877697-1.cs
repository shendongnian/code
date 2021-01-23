        public Fabrika(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }
        [Association]
        public Departman Departman;
        
    }
