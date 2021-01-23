    [STAThread]
            static void Main()
            {          
                Customer cust = new Customer();
                cust.Address.Address1 = "HAllo";
            }
    
            public abstract class ViewModel : INotifyPropertyChanged
            {
                public event PropertyChangedEventHandler PropertyChanged;
    
                protected void OnPropertyChange(string propertyName)
                {
                    if (PropertyChanged == null) return;
    
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }   
            }
    
            public class Customer : ViewModel
            {
                public Address Address { get; set; } //this implements inpc but I don't show that here.
                public Customer()
                {
                    Address = new Program.Address();
                    // I get nothing here. But why?
                    Address.PropertyChanged += (o, e) => Console.WriteLine("Just do something, please!");
    
                    // What I want to do is get Customer propertychange to fire
                    // Because currently Address changes are not detected.
                }
            }
    
            public class Address : ViewModel
            {
                private string _addy = "";
                public string Address1
                {
                    get { return _addy; }
                    set
                    {
                        _addy = value;
                        Console.WriteLine("Testing that at least something works");
                        // I have verified that this is getting called, firing the event.
                        OnPropertyChange("Addy");
                    }
                }
            }
