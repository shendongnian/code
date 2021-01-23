    public class MyModel
    {
        private _myEmpls{get;set;}
        public Employees[] MyEmpls{
         get{return _myEmpls;}
         set{_myEmpls=(value==null?new List<Employees>():value);}
        }
        public int Id{get;set;}
        public OrgName{get;set;}
    }
