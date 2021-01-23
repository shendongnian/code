    public class Country
    {
        private string _name;
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        public ObservableCollection<State> States { get; set; }
    }
