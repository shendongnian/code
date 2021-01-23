    protected void Page_Load(object sender, EventArgs e)
            {
                List<Place> items = new List<Place>();
                items.Add(new Place() { RoomType = "RoomType1", Description = "RoomType Description" });
                items.Add(new Place() { RoomType = "RoomType2", Description = "RoomType Description" });
                items.Add(new Place() { RoomType = "RoomType3", Description = "RoomType Description" });
                this.ListView1.DataSource = items;
                this.ListView1.DataBind();
            }
