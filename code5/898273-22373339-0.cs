    static void Main(string[] args)
    {
      Stack<Data> s = new Stack<Data>();
      Data d = new Data(10);
      d.Freeze();
      s.Push(d);
      d.Value = 20;
      Console.WriteLine("Frozen value : {0}", s.Pop().Value);
      Console.WriteLine("actual value : {0}", d.Actual(data => data.Value));
      Console.ReadKey();
    }
      class FreezableValue<T>
      {
        private T frozenValue;
        private T actualValue;
        private bool isFrozen;
    
        public void Freeze()
        {
          isFrozen = true;
        }
    
        public T ActualValue
        {
          get
          {
            return actualValue;
          }
          set
          {
            this.actualValue = value;
            if(!isFrozen)
              frozenValue = value;
          }
        }
    
        public T FrozenValue { get { return frozenValue; } }
      }
    
      class Data
      {
        private readonly FreezableValue<int> freezableValue;
        private bool useActualValue;
    
        public Data(int value)
        {
          freezableValue = new FreezableValue<int> { ActualValue = value };
          useActualValue = true;
        }
    
        public void Freeze()
        {
          freezableValue.Freeze();
          useActualValue = false;
        }
    
        public int Value
        {
          get { return useActualValue ? freezableValue.ActualValue : freezableValue.FrozenValue; }
          set { freezableValue.ActualValue = value; }
        }
    
        public T Actual<T>(Func<Data, T> func)
        {
          useActualValue = true;
          try
          {
            return func(this);
          }
          finally
          {
            useActualValue = false;
          }
        }
      }
