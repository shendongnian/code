    Class A
    {
        public void Print()
        { 
    	    StartingProcedure();
    		SpecificPrint();
    		EndingProcedure();
        }
        protected void StartingProcedure()
        {
            /// something 
        }
        protected void EndingProcedure()
        {
            /// something 
        }
    	protected virtual SpecificPrint()
        {
        }
    }
    
    Class A_1 : A
    {
        public override void SpecificPrint()
        {
            /// class specific print operation
        }
    }
    
    Class A_2 : A
    {
        public override void SpecificPrint()
        {
            /// class specific print operation
        }
    }
