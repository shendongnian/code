    public class Component
    {
        private ObservableCollection<ComponentParameter> parameters = new ObservableCollection<ComponentParameter>();
        public string Name
        {
          get;
          set;
        }
        public ObservableCollection<ComponentParameter> Parameters
        {
            get{return parameters;}
            set{parameters = value;}
        }
        public bool IsAnyParameterMissing
        {
            get { return this.Parameters.Any(param => param.IsMissing); }
        }
    }
