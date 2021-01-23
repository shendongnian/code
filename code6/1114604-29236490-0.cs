    public class TypeARepository
    {
        private ISpecializedDependencyForB depB;
        private ISpecializedDependencyForC depC;
        public TypeARepository(ISpecializedDependencyForB depB, ISpecializedDependencyForC depC)
        {
            this.depB = depB;
            this.depC = depC;
        }
    
        public TypeA GetById(string id)
        {
            if (id == 1)
            {
                return new TypeB(depB);
            }
            else
            {
                return new TypeC(depC);
            }
        }
    }
