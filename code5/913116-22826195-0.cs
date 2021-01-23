    public class BonusViewModel : ViewModelBase
    {
        // ViewModelBase is an abstract class that implements INPC
        public BonusViewModel(Bonus model)
        {
            Model = model;
        }
        public Model Bonus { get; private set; }
    
        public string Name 
        {
            get { return Model.Name; }
            set { Model.Name = value; OnPropertyChanged("Name");}
        }
    
        public string FunnyName
        {
            get { return string.Format("{0} is so funny", Name); }
        }
    }
