     SortableBindingList<Person> sblist = new SortableBindingList<Person>();
     foreach (Person p in _mainManager.ListOfPeople)
     {
         sblist.Add(p);
     }
     _rotaView.DataSource = sblist;
