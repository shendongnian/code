    public string SearchText
    {
        get
        {
            return _searchText;
        }
        set
        {
            if(_searchText == value)
                return;
            _searchText = value;
            Contacts.Clear();
            foreach(var item in _baseContactList.Where(contact => 
                contact.Name.Contains(_searchText))
            {
                Contacts.Add(item);
            }
        }
