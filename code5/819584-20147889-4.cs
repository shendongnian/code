    class GridViewDataSource
    {
        // the id of the description type
        public int DescriptionId { get; set; } 
    }
    
    // again, this probably is taken from db
    gridControl2.DataSource = new GridViewDataSource[] 
    {
           new GridViewDataSource {  DescriptionId = 1 },
           new GridViewDataSource {  DescriptionId = 2 },
           new GridViewDataSource {  DescriptionId = 1 },
           new GridViewDataSource {  DescriptionId = 2 },
    };
