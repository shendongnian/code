    public class SampleViewModel : NotificationObject
    {
        private Entity Model {get;set;}
    
        public string HasEntries
        {
            get
            {
                if(Model.Entries.Count > 0)
                    return "Model has Entries";
                else
                    return "Model has no Entries";
            }
        }
        public void AddEntry(Entry entry)
        {
             Model.Entries.Add(entry);
             //Execute you nofity property changed
             NotifyPropertyChanged("HasEntries");   
        }
    }
