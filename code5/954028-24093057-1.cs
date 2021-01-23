    namespace WpfApplication3
    {
        public class Vm
        {
            public ObservableCollection<ObserverableGrouping> Source { get; set; }
            public Vm()
            {
                Source = new ObservableCollection<ObserverableGrouping>() { 
                    new ObserverableGrouping("Group1"){ new ObjectModel() { Name = "A", Description = "Group1 Object1" }, new ObjectModel() { Name = "B", Description = "Group1 Object2" } },
                    new ObserverableGrouping("Group2"){ new ObjectModel() { Name = "C", Description = "Group2 Object1" }, new ObjectModel() { Name = "D", Description = "Group2 Object2" } }
                };
            }
        }
        public class ObserverableGrouping : ObservableCollection<ObjectModel>
        {
            public string GroupDescription { get; set; }
            public ObserverableGrouping(string Name)
            {
                this.GroupDescription = Name;
            }
        }
        public class ObjectModel
        {
            public string Name {get;set;}
            public string Description {get;set;}
        }
    }
