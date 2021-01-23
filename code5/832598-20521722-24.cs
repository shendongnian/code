    public class Staff_VM
    {
        public int ID { get; set; }
        public int SalutationID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public bool Active { get; set; }
    }
    public class MyViewModel
    {
        public Staff_VM StaffVm { get; set; } 
        public List<Staff_VM> ListStaffVms { get; set; }
        public List<Prm_Salutation> AvailableSalutations { get; set; }
    }
