    this.Entities.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(EntitiesItems_CollectionChanged);
    void  EntitiesItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e){
            if (e.NewItems != null) {
                ((EntityModel)e.NewItems[0]).PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(TrailPoints_PropertyChanged);
            }
            OnPropertyChanged("Entities");
        } 
    void TrailPoints_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            if (e.PropertyName == "TrailPoints") {
                OnPropertyChanged("Entities");
            }
           
        }
