    public NewCountryClass(string country)
    {
        _places = new ObservableCollection<string>();
        if (country != null)
        {
            _country = country;
        }
}
