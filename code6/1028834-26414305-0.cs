    public class Students_Classes
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Students))]
        public int StudentFId { get; set; }
        [ForeignKey(typeof(Classes))]
        public int ClassFId { get; set; }
    }
