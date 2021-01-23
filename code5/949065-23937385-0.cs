    interface IDataComparer<T>
    {
        void CompareSomeData(T instance);
    }
    class A : IDataComparer<A>
    {
        public virtual void CompareSomeData(A instanceOfA) { }
    }
    class B : A, IDataComparer<B>
    {
        public override void CompareSomeData(A instanceofA)
        {
            throw new ArgumentException("...");
        }
        public virtual void CompareSomeData(B instanceOfB)
        {
            base.CompareSomeData(instanceOfB);
        }
    }
    class C : A, IDataComparer<C>
    {
        public override void CompareSomeData(A instanceofA)
        {
            throw new ArgumentException("...");
        }
        public virtual void CompareSomeData(C instanceOfC)
        {
            base.CompareSomeData(instanceOfC);
        }
    }
