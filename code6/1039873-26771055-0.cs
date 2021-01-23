    public class Institution
    {
        public Institution()
        {
                Addresses = new Addresses<Student>();
        }
    
        [Key]
        public int ID { get; set; }
        [Display(Name="Institution Name")]
        public string Name { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
