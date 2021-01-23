    class Class1
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                //Check if you are assigning the same value. Depends on your business logic
                //here is the simplest check
                if (Equals(name, value))
                    return;
                name = value;
                OnNameChanged();
            }
            public event EventHandler NameChanged;
            protected virtual void OnNameChanged()
            {
                var handler = NameChanged;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }
    }
