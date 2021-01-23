    class MySpecialDetails
    {
        // declare as private variable in scope of class
        // hence it can be accessed by all methods in this class
        private GetDetails _details; // don't name your type "Get..." ;-)
        
        public GetDetails GetInfo()
        {
            // save result into local variable
            return (_details = new GetDetails("john", 47));
        }
        public override string ToString()
        {
            // read local variable
            return _details != null ? _details.Name + "|" + _details.Age : base.ToString();
        }
    }
