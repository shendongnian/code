    using DapperTestProj.DapperAttributeMapper;
    namespace DapperTestProj.Entities
    {
        public class Table1
        {
            [Column("Table1Id")]
            public int Id { get; set; }
            public string Column1 { get; set; }
            public string Column2 { get; set; }
            public Table2 Table2 { get; set; }
            public Table1()
            {
                Table2 = new Table2();
            }
        }
    }
