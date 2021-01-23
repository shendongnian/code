                        DataReceivedCollection = new ObservableCollection<Data>();
                        DispatchInvoke(() =>
                        {
                            myList.ItemsSource = DataReceivedCollection;
                            // and to add data you do it like this:
                            DataReceivedCollection.Add(new Data() { symid = ID, textFirst = Name, textSecond = Bid, textThird = Ask });
                        }
