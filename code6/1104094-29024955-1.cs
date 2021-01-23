    public class ClassA : ISomething
    {
        public ClassA (ManagerClass managerClass){
            this.managerClass = managerClass;
        }
        public double Property { get; set; }
        private ManagerClass managerClass = null;
        public ManagerClass ManagerClass { get { return managerClass; } }
        private ClassB classB null;
        public ClassB ClassB { get{ return classB; } }
        public void SetClassB(ClassB classB){
            // check whether 
            if(classB != null && !ManagerClass.ISomethings.Any(k=> k==classB)){
                this.classB = classB;
            }
            // set null
            else if(classB == null){
                this.classB = null;
            }
            else {
                throw new Exception("not found");
            }
        }
    }
