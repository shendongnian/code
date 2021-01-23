    public partial class User
    {
        public int ID { get; set; }
        [RegularExpression("regex for emails is much harder than you think")]
        public string Email { get; set; }
        [MaxLenght(20)]
        public string FullName { get; set; }
    }
