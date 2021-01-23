    public class AssessmentItem
    {
        public string Label { get; set; }
        public string Explanation { get; set; }
        public string ResourceURL { get; set; }
        public BitmapImage Icon { get; set; }
        public RunFixer Fixer { get; set; }
        ICommand _fixerCommand = new UICommand();
        public ICommand FixerCommand {
            get
            {
                _fixerCommand = _fixerCommand ?? new DelegateCommand<object>((o)=>
                           {var f = Fixer;
                             if(f != null) f();}); 
                return _fixerCommand;}
            }
    }
