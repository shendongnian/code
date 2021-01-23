    public class Stock : IEnumerable<Valuation>
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(8)]
        public string Symbol { get; set; }
        [ForeignKey(typeof(StockGrouping))]
        public int StockGroupingId { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]      // One to many relationship with Valuation
        public List<Valuation> Valuations { get; set; }
        public IEnumerator<Valuation> GetEnumerator() {
            return Valuations.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return Valuations.GetEnumerator();
        }
    }
