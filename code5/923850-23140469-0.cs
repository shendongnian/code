    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        Results trackResults = (Results)Session["Result"];
        //create datatable and columns,
        DataTable table = new DataTable();
        table.Columns.Add("Artist Name");
        table.Columns.Add("Collection Name");
        table.Columns.Add("Track Name");
        table.Columns.Add("Artwork");
        table.Columns.Add("Track Price");
        table.Columns.Add("Release Date");
        table.Columns.Add("Genre");
        foreach (Tracks t in trackResults.results)
        {
            DataRow dr1 = table.NewRow();
            dr1["Artist Name"] = t.artistName;
            dr1["Collection Name"] = t.collectionName;
            dr1["Track Name"] = t.trackName;
            dr1["Artwork"] = t.artworkUrl30;
            dr1["Track Price"] = t.trackPrice;
            dr1["Release Date"] = t.releaseDate;
            dr1["Genre"] = t.primaryGenreName;
            table.Rows.Add(dr1);
        }
        GridView1.DataSource = table;
        GridView1.DataBind();
