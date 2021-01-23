      public class Departman : XPObject
    {
        public Departman(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        
        [Association]
        public Fabrika Fabrika;
    }
