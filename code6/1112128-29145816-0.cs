            private void DoAdd()
            {
                Records.Add( new Record
                {
                    Name = "Added",
                    TotalCount = Records.Count + 1
                });
    
                Records = new ObservableCollection<Record>(Records);
                OnPropertyChanged("Records");
            }
