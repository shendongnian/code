    using System.ComponentModel;
    using System.Collections.ObjectModel;
    public class Stuff
    {
        public Stuff(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
    }
    ObservableCollection<Stuff> myData = new ObservableCollection<Stuff>();
    myData.Add(new Stuff("abcd"));
