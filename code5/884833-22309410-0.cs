    public string SortOrder
    {
        get
        {
            return _sortOrder;
        }
        set
        {
            if(_sortOrder == value)
                return;
            _sortOrder = value;
            Contacts.Clear();
            // continue adding values for each possible sort order
            // A faster way to do this would be to do the check once,
            // But this looks nicer
            foreach(var item in _baseContactList.OrderBy(contact => 
                _sortOrder == "Name" ? contact.Name :
                _sortOrder == "Email" ? contact.Email))
            {
                Contacts.Add(item);
            }
        }
