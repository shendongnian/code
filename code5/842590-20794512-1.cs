    public void AddRange(IEnumerable<T> dataToAdd)
            {
                this.CheckReentrancy();
     
                //
                // We need the starting index later
                //
                int startingIndex = this.Count;
     
                //
                // Add the items directly to the inner collection
     
                //
                foreach (var data in dataToAdd)
                {
                    this.Items.Add(data);
                }
     
                //
                // Now raise the changed events
                //
                this.OnPropertyChanged("Count");
                this.OnPropertyChanged("Item[]");
     
                //
                // We have to change our input of new items into an IList since that is what the
                // event args require.
                //
                var changedItems = new List<T>(dataToAdd);
                this.OnCollectionChanged(changedItems, startingIndex);
            }
