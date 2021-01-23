    public partial class country
    {
        public byte country_id { get; set; }
        public string country_name { get; set; }
        public DbSet<state> states { get; set; }
    }
