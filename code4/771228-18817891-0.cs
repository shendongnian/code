    public class VehicleAssignElement
    {
        public VehicleAssignElement(string pkgID, string driverID, string vehicleID)
        {
            this.PkgID = pkgID;
            this.DriverID = driverID;
            this.VehicleID = vehicleID;
        }
        public string PkgID { get; set; }
        public string DriverID { get; set; }
        public string VehicleID { get; set; }
    }  
    public class Form1 : Form
    {
        private List<VehicleAssignElement> _assignmentList = new List<VehicleAssignElement>();
        public void DoSomething()
        {
            VehicleAssignElement assignment1 = new VehicleAssignElement("pkg1", "John", "Audi");
            _assignmentList.Add(assignment1);
            
            VehicleAssignElement assignment2 = new VehicleAssignElement("pkg2", "Morgan", "Volkswagen");
            _assignmentList.Add(assignment2);
            foreach(var assignment in _assignmentList)
            {
                Debug.WriteLine(string.Format("{0} -> {1} - {2}", assignment.PkgID, assignment.DriverID, assignment.VehicleID));
            }
        }
    }
