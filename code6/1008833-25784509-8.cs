    class Presenter
    {
        private IModel _myModel...
        private IRepository _repository;
        public Presenter(IView_MainForm view, IRepository repository)
        {
            _repository = repository;
            this.View = view;
            this.View.LoadInput_01 += new EventHandler<InputLoadEventArgs>(OnLoadInput_01);
            this.View.LoadInput_02 += new EventHandler<InputLoadEventArgs>(OnLoadInput_02);
        }
    
        public void OnLoadInput_01(object sender, InputLoadEventArgs e)
        {
             // get data based on passed arguments (e.SomeProperty)
             // construct IModel
             myModel = _repository.GetData(e.SomeProperty);
             // pass data to IView_MainForm
             View.SetInput01Data(myModel.Input01Data);
         }
    }
