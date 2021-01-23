    using System;
    using System.ComponentModel;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            class Notifications
            {
                static void Main(string[] args)
                {
                    var daveNadler = new Person {Name = "Dave"};
                    daveNadler.PropertyChanged += PersonChanged;
                }
    
                static void PersonChanged(object sender, PropertyChangedEventArgs e)
                {
                    Console.WriteLine("Something changed!");
                    Console.WriteLine(e.PropertyName);
                }
            }
        }
    
        public class Person : INotifyPropertyChanged
        {
            private string _name = string.Empty;
            private string _lastName = string.Empty;
            private string _address = string.Empty;
    
            public string Name
            {
                get { return this._name; }
                set
                {
                    this._name = value;
                    NotifyPropertyChanged("Name");
                }
            }
    
            public string LastName
            {
                get { return this._lastName; }
                set
                {
                    this._lastName = value;
                    NotifyPropertyChanged("LastName");
                }
            }
    
            public string Address
            {
                get { return this._address; }
                set
                {
                    this._address = value;
                    NotifyPropertyChanged("Address");
                }
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
        }
    }
