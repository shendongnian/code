    public class God {
        
        readonly ObservableCollection<Believer> Believers = new ObservableCollection<Believer>();
    
        public God() {
            Believers  = new ObservableCollection<T>();
            Believers.CollectionChanged += BelieversListChanged;
        }
    
        private void BelieversListChanged(object sender, NotifyCollectionChangedEventArgs args) {
           
            if ((e.Action == NotifyCollectionChangedAction.Remove || e.Action ==     NotifyCollectionChangedAction.Replace) && e.OldItems != null)
            {
                foreach (var oldItem in e.OldItems)
                {
                    var bel= (Believer)e.oldItem;               
                    bel.Prayed -= Believer_Prayed; 
                }
            }
            if((e.Action==NotifyCollectionChangedAction.Add ||               e.Action==NotifyCollectionChangedAction.Replace) && e.NewItems!=null)
                {
                    foreach(var newItem in e.NewItems)
                    {
                       foreach (var oldItem in e.OldItems)
                    {
                        var bel= (Believer)e.newItem;               
                        bel.Prayed += Believer_Prayed; 
                    }
                }
            }
        }
    
        void Believer_Prayed(Believer believer, string prayer) {
            //whatever
        }
    }
