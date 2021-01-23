    <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
        <ItemTemplate>
            <uc1:MoviePanel runat="server" id="MovieDetailPanel1" />
        </ItemTemplate>
    </asp:Repeater>
    
    public class Movie
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Repeater1.DataSource = new List<Movie>
            {
                new Movie {MovieID = 1, MovieName = "One", MovieDescription = "One hundred"},
                new Movie {MovieID = 2, MovieName = "Two", MovieDescription = "Two hundreds"},
                new Movie {MovieID= 3, MovieName = "Three", MovieDescription = "Three hundreds"},
            };
            Repeater1.DataBind();
        }
    }
    
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var movie = e.Item.DataItem as Movie;
    
            var control = e.Item.FindControl("MovieDetailPanel1") as MoviePanel;
            control.myMovieID = movie.MovieID;
            control.myMovieDescription = movie.MovieDescription;
            control.myMovieName = movie.MovieName;
        }
    }
