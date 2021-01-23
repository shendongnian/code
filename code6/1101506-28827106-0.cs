    class DataRecord
    {
        public Guid ID { get; set; }
        public String Name { get; set; }
        public DateTime CreateDate { get; set; }
    };
    List<DataRecord> data = new List<DataRecord>()
    {
        new DataRecord()
        {
            ID = Guid.NewGuid(),
            Name = "Record 1",
            CreateDate = DateTime.Now
        },
        new DataRecord()
        {
            ID = Guid.NewGuid(),
            Name = "Record 2",
            CreateDate = DateTime.Now.AddDays(-1)
        }
    };
    gridView.DataSource = data.OrderBy(x => x.CreateDate);
    gridView.DataBind();
