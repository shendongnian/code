    class A
    {
        public virtual A Plus(A right)
        {
            return new A();
        }
        public static A operator + (A left, A right)
        {
            //Calculations and handle left == null case.
            return left.Plus(right);
        }
    }
    
    class B : A
    {
        public override B Plus(B right)
        {
            //Calculations
            base.Plus(right);
            return new A();
        }
    }
