    public partial class CustomControl1 : UserControl
    {
        public CustomControl1(bool addDummies = false)
        {
            this.InitializeComponents();
            this.Persons = new ObservableCollection<Person>();
            if (addDummies)
            {
                this.Persons.Add(new Person() { Name = "Sarah" });
                // etc
            }
        }
    }
