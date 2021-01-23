    public class IncidentAddress {
      public string Address { get; set; }
      private RelayCommand zoomCommand; 
      public RelayCommand ZoomCommand {
        get {
          if (zoomCommand == null)
            zoomCommand = new RelayCommand(Zoom);
          return zoomCommand;
        }
      }
      public void Zoom() {
        MessageBox.Show(Address);
      }
    }
