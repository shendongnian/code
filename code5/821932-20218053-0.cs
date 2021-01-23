    public class ProjectViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Project> Projects { get; set; }
        public Project SelectedProject { get; set; }
        public ObservableCollection<Proforma> Proformas { get; set; }
        public Proforma SelectedProforma { get; set; }
        public ObservableCollection<Shipment> Shipments { get; set; }
        public Shipment SelectedShipment { get; set; }
        public void LoadProjects() {}
        public void LoadProformas() {}             
        public void LoadShipments() {}             
    }
