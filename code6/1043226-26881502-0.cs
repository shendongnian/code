    interface IOperator
    {
        int Operation(int a, int b);
        float Operation(float a, float b);
        decimal Operation(decimal a, decimal b);
    }
    class Adder : IOperator
    {
        public int Add(int a, int b){}
        public float Add(float a, float b){}
        public decimal Add(decimal a, decimal b){}
        public int Operation(int a, int b) { return Add(a, b); }
        public float Operation(float a, float b) { return Add(a, b); }
        public decimal Operation(decimal a, decimal b) { return Add(a, b); }
    }
    
    
    class Subber : IOperator
    {
        public int Sub(int a, int b){}
        public float Sub(float a, float b){}
        public decimal Sub(decimal a, decimal b){}
        public int Operation(int a, int b) { return Sub(a, b); }
        public float Operation(float a, float b) { return Sub(a, b); }
        public decimal Operation(decimal a, decimal b) { return Sub(a, b); }
    }
