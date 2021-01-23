             ObservableCollection<Product> products = new ObservableCollection<Product>();
               //Replace the lst with your control
                    var lst = new List<Product>();
                products.CollectionChanged += (sender, eve) =>
                {
                    switch (eve.Action)
                    {
                        
                        case NotifyCollectionChangedAction.Add:
                            //add to your control here    
                            lst.Add((Product) eve.NewItems[0]);
                            break;
                        case NotifyCollectionChangedAction.Remove:
                             //add implementation here
                            break;
                        case NotifyCollectionChangedAction.Replace:
                            break;
                        case NotifyCollectionChangedAction.Move:
                            break;
                        case NotifyCollectionChangedAction.Reset:
                            break;
                    }
                };
