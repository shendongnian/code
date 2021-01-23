    public class StaffDetails
    {
        public StaffDetails()
        {
          this.Address = new Address();
        }
        [Key]
        public int StaffId { get; set; }
        public int UnvId { get; set; }
        public University University { get; set; }
        public int SportsID { get; set; }
        public SportsCode SportsCode { get; set; }
        public int SportsGroupId { get; set; }
        public SportsGroup SportsGroup { get; set; }
        public int CoachingStaffId { get; set; }
        public CoachingStaff CoachingStaff { get; set; }
        public string Name { get; set; }
        public string SportsAffliation { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string OrganizationalLeader { get; set; }
        public Address Address { get; set; }
    }
