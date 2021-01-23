    public interface IContractor
        {
            int Id { get; set; }
            string Name { get; set; }
        }
    
        public partial class FTContractor : IContractor
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    public partial class PTContractor : IContractor
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
