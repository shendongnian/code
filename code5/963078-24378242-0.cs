    public class SinhVien
    {
        [Key]
        public int SinhVienId { get; set; }
        public string Name { get; set; }    
        public string Address { get; set; }
        public DateTime BirthDay { get; set; }
        public int GroupId { get; set; }
        [ForeignKey(Name="GroupID")]
        public virtual Group Group { get; set; }
    }
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        public string Name { get; set; }       
    }
