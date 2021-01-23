    public partial class Company
    {
        public Company()
        {
            this.Branches = new List<Branch>();
        }
        ....
        [JsonIgnore]
        public virtual List<Branch> Branches { get; set; }
}
