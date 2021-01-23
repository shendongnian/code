    public class Machines
        {
            private string machinename;
    
            public string machineName
            {
                get { return machinename; }
                set { machinename = value; }
            }
            private ObservableCollection<DriveList> driveList;
    
            public ObservableCollection<DriveList> DriveList
            {
                get { return driveList; }
                set { driveList = value; }
            }
           
    
        }
    
        public class ViewModel
        {
            private ObservableCollection<Machines> machines;
    
            public ObservableCollection<Machines> MachineList
            {
                get { return machines; }
                set { machines = value; }
            }
            public ViewModel()
            {
                ObservableCollection<DriveList> list= new ObservableCollection<DriveList>();
                list.Add(new DriveList() { driveName = "Drive 1" });
                machines = new ObservableCollection<Machines>();
                machines.Add(new Machines() { machineName = "Machine 1", DriveList =list  });
            }
        }
    
        public class DriveList
        {
            private string drivename;
    
            public string driveName
            {
                get { return drivename; }
                set { drivename = value; }
            }
        }
