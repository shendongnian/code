    class ClassWithImportantProperty
    {
        string myString = string.Empty;
        public string MyImportantProperty
        {
            get { return myString; }
            set
            {
                myString = value;
                if (PropertyChanged != null)
                    PropertyChanged(myString, EventArgs.Empty);
            }
        }
        public event EventHandler PropertyChanged;
    }
    class SecondClass
    {
        public string MyDependantString { get; set; }
         public secondClass()
         {
             var classInstance = new ClassWithImportantProperty();
             classInstance.PropertyChanged += classInstance_PropertyChanged;
         }
         void classInstance_PropertyChanged(object sender, EventArgs e)
         {
             MyDependantString = sender.ToString();
         } 
    }
