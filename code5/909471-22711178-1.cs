    public class ClassB
    {
        readonly Ref<ClassA> refClassA;
        public ClassA ClassA
        {
            get
            {
                return refClassA.Value;
            }
        }
        public ClassB(Ref<ClassA> refClassA)
        {
            this.refClassA = refClassA;
        }
        public void Print()
        {
            Console.WriteLine(ClassA.VariableA);
        }
    }
