        public void InitView()
        {
            combo2 = CollectionViewSource.GetDefaultView(combo);
            combo2.Filter = (i) => i != selectedTeam;
        }
        
