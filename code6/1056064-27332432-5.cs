       private void peopleDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (object ro in e.RemovedItems)
            {
                Person rp = ro as Person;
                if(rp != null)
                    rp.IsSelected = false;
            }
            foreach (object so in e.AddedItems)
            {
                Person sp = so as Person;
                if (sp != null)
                    sp.IsSelected = true;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
