    class CalculatorViewModel
    {
        public CalculatorViewModel()
        {
            ActionCommand = new ActionCommand(this);
            ...
        }
        public ActionCommand ActionCommand { get; private set; }
        ...
    }
