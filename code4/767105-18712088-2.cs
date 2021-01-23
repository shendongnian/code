    public DataClassViewModel
    {
        //Define all relevant properties here.
        ...
        public DataClassViewModel(DataClass model) //Constructor
        {
           //Initialize the view model from the model. 
        }
        public DataClass GetModel()
        {
           //Depending on changes in the view model, model could be updated here.
        }
        public void UpdateData()
        {
        }
    }
