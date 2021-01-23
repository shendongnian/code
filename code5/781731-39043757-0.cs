    public static ObservableCollection<string> OrderThoseGroups( ObservableCollection<string> orderThoseGroups)
        {
            ObservableCollection<string> temp;
            temp =  new ObservableCollection<string>(orderThoseGroups.OrderBy(p => p));
            orderThoseGroups.Clear();
            foreach (string j in temp) orderThoseGroups.Add(j);
            return orderThoseGroups;
        }
