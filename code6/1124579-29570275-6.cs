    CurrentFacilityVM = null;
    CurrentTankVM =null;
    CurrentContainerVM =null;
    if (selectedItem is Facility)
    {
    CurrentFacilityVM = new FacilityViewModel(selectedItem as Facility);     
    }
    if (selectedItem is Tank)
    {
    CurrentTankVM = new TankViewModel(selectedItem as Tank);     
    }
    if (selectedItem is Containers)
    {
    CurrentContainerVM = new ContainersViewModel(selectedItem as Containers);     
    }
