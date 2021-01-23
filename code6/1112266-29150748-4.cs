	dgv.DataSource = GetSortableBindingList(
		new[] {
			new { CompanyName = c.Name, ContactPerson = c.Contact.Name, HQ = c.HQAddress.City + ", " + c.HQAddress.Country},
			new { CompanyName = "Akshar Inc.", ContactPerson = p2.Name, HQ = "LA, USA"}
		}
	);
    // Wrapper method to allow dynamic objects
    public object GetSortableBindingList<T>(IEnumerable<T> collection) where T : class
    {
    	return new ObservableCollection<T>(collection).ToBindingList();
    }
