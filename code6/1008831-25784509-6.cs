    interface IView_MainForm
    {
        //  Load input
        //
        event EventHandler<InputLoadEventArgs> LoadInput_01;
        event EventHandler<InputLoadEventArgs> LoadInput_02;
    
        bool Input01_Loaded { get; set; }
        bool Input02_Loaded { get; set; }
        ComplexType Input01Data {get;set;} // you might actually have some code in get/set setters
        ComplexType Input02Data {get;set;} // you might actually have some code in get/set setters
        public void SetInput01Data(ComplexType input01Data)
        {
           Input01Data = input01Data;
           // some other stuff
        }
    }
