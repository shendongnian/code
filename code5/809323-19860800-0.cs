    [Table("Practitioners")]
    public class PractitionerModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set;}
        [ForeignKey("Specialties")]
        public virtual int Code {get; set; }
        public ICollection<SpecialityModel> Specialities { get; set; }
    }
    [Table("Specialities")]
    public class SpecialityModel
    {
        public virtual int Id { get; set;}
        public string Name { get; set; }
        public int Code { get; set; }
    }
