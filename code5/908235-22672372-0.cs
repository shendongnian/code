    public List<string> MyItemsSource
    {
        get 
        {
            var myNewList = MyMasterList.ToList(); //create a (reference) copy of the master list (the items are not copied though, they remain the same in both lists)
            if (PropertyA != null)
                myNewList.Remove(PropertyA);
    
            return myNewList;
        }
    }
