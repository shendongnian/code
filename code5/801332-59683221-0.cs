    var req = Listbox1.SelectedItems.OfType<string>().ToList().Where(c => c == item.Name).FirstOrDefault();
    if (req==null)
    {
        var a = MyMapView.Map.OperationalLayers.Where(c => c.Name == item.Name).FirstOrDefault();
        MyMapView.Map.OperationalLayers.Remove(a);
    }
