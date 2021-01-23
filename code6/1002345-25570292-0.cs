    //Model
    public class JobList
    {
        public string jobName { get; set; }
        public double Price { get; set; }
        public List<Options> option { get; set; }
        public JobList(){
        option = new List<Options>();
    }
    public class Options
    {
        [Required]
        public JobList joblist { get; set; }
        [Key]
        public int id { get; set; }
        public double Price { get; set;}
    }
