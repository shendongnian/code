    interface IDescribeSomething
    {
       void Process(SomeBaseType type);
    }
    interface IDescribeSomething<T> : IDescribeSomething
    {
       void Process(T type);
    }
    class APieceOfState : SomeBaseType {}
    class ImplementWhatIsDescribed : IDescribeSomething<APieceOfState>
    {
        public void Process(SomeBaseType type)
        {
            Process((APieceOfState)type);
        }
        public void Process(APieceOfState type)
        {
            Console.WriteLine("Processing {0}", type.GetType());
        }
    }
    IDescribeSomething instance = 
         (IDescribeSomething)Activator.CreateInstance(lookupProcessorType);
    instance.Process(task);
    // but in this case you can sometime write strongly type one too
    // if you got strongly typed version of interface 
    IDescribeSomething<APieceOfState> p =...
    p.Process(task)
