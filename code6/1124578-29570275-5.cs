    if (selectedItem is Facility)
    {
    CurrentBaseXXX= new FacilityViewModel(selectedItem as Facility);     
    }
    if (selectedItem is Tank)
    {
    CurrentBaseXXX= new TankViewModel(selectedItem as Tank);     
    }
    if (selectedItem is Containers)
    {
    CurrentBaseXXX= new ContainersViewModel(selectedItem as Containers);     
    }
