    [ServiceContract]
    interface IMyCalculator
    {
        //Providing alias AddInt, to avoid naming conflict at Service Reference
        [OperationContract(Name = "AddInt")]
        public int Add(int numOne, int numTwo);
    
        //Providing alias AddDobule, to avoid naming conflict at Service Reference
        [OperationContract(Name = "AddDouble")]
        public double Add(int numOne, double numTwo); 
    }
