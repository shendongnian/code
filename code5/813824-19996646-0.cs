     obsList.CollectionChanged += (sender, eventArgs) =>
                    {
                        switch (eventArgs.Action)
                        {
                            case NotifyCollectionChangedAction.Remove:
                                foreach (var oldItem in eventArgs.OldItems)
                                {
                                  
                                }
                                break;
                            case NotifyCollectionChangedAction.Add:
                              
                                break;
                        }
                    };
