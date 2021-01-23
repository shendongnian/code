    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class RepaterDataInHTML : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Movie> DBrep = new List<Movie>();
            DBrep = new DataBaseInFormOfList().GetMovies();
            List<Movie> DBsort = new List<Movie>();
            if (Request.QueryString["SortBy"] != null)
            {
                string SortBy = Request.QueryString["SortBy"].ToString();
                if (SortBy == "Title")
                {
                    DBsort = DBrep.OrderBy(o => o.Title).ToList();
                }
                else if (SortBy == "Director")
                {
                    DBsort = DBrep.OrderBy(o => o.Director).ToList();
                }
                else if (SortBy == "Genre")
                {
                    DBsort = DBrep.OrderBy(o => o.Genre).ToList();
                }
                else if (SortBy == "RunTime")
                {
                    DBsort = DBrep.OrderBy(o => o.RunTime).ToList();
                }
                else if (SortBy == "ReleaseDate")
                {
                    DBsort = DBrep.OrderBy(o => o.ReleaseDate).ToList();
                }
                else
                {
                    DBsort = DBrep;
                }
                _repDB.DataSource = DBsort;
                _repDB.DataBind();
            }
            else
            {
                //Response.Write("No Data Found");
            }
        }
    }
    public class DataBaseInFormOfList
    {
        public List<Movie> GetMovies()
        {
            return new List<Movie> {
                    new Movie { Title="Shrek", Director="Andrew Adamson", Genre=0,
                       ReleaseDate=DateTime.Parse("16-05-2001"), RunTime=89 },
                     new Movie { Title="Fletch", Director="Michael Ritchie", Genre=0,
                       ReleaseDate=DateTime.Parse("31-05-1985"), RunTime=96 },
                    new Movie { Title="Casablanca", Director="Michael Curtiz", Genre=1,
                       ReleaseDate=DateTime.Parse("01-01-1942"), RunTime=102 },
                    new Movie { Title="Batman", Director="Tim Burton", Genre=1,
                       ReleaseDate=DateTime.Parse("23-03-1989"), RunTime=126 },
                    new Movie { Title="Dances with Wolves",
                       Director="Kevin Costner", Genre=1,
                       ReleaseDate=DateTime.Parse("21-11-1990"), RunTime=180 },
                    new Movie { Title="Dirty Dancing", Director="Emile Ardolino", Genre=1,
                       ReleaseDate=DateTime.Parse("21-08-1987"), RunTime=100 },
                    new Movie { Title="The Parent Trap", Director="Nancy Meyers", Genre=0,
                       ReleaseDate=DateTime.Parse("29-07-1998"), RunTime=127 },
                    new Movie { Title="Ransom", Director="Ron Howard", Genre=1,
                       ReleaseDate=DateTime.Parse("08-11-1996"), RunTime=121 },
                    new Movie { Title="Ocean's Eleven",
                       Director="Steven Soderbergh", Genre=1,
                       ReleaseDate=DateTime.Parse("07-12-2001"), RunTime=116 },
                    new Movie { Title="Steel Magnolias", Director="Herbert Ross", Genre=1,
                       ReleaseDate=DateTime.Parse("15-11-1989"), RunTime=117 },
                    new Movie { Title="Mystic Pizza", Director="Donald Petrie", Genre=1,
                       ReleaseDate=DateTime.Parse("21-10-1988"), RunTime=104 },
                    new Movie { Title="Pretty Woman", Director="Garry Marshall", Genre=1,
                       ReleaseDate=DateTime.Parse("23-03-1990"), RunTime=119 },
                    new Movie { Title="Interview with the Vampire",
                       Director="Neil Jordan", Genre=1,
                       ReleaseDate=DateTime.Parse("11-11-1994"), RunTime=123 },
                    new Movie { Title="Top Gun", Director="Tony Scott", Genre=2,
                       ReleaseDate=DateTime.Parse("16-05-1986"), RunTime=110 },
                    new Movie { Title="Mission Impossible",
                       Director="Brian De Palma", Genre=2,
                       ReleaseDate=DateTime.Parse("22-05-1996"), RunTime=110 },
                    new Movie { Title="The Godfather", Director="Francis Ford Coppola",
                       Genre=1, ReleaseDate=DateTime.Parse("24-03-1972"), RunTime=175 },
                    new Movie { Title="Carlito's Way", Director="Brian De Palma",
                       Genre=1, ReleaseDate=DateTime.Parse("10-11-1993"), RunTime=144 },
                    new Movie { Title="Robin Hood: Prince of Thieves",
                       Director="Kevin Reynolds",
                       Genre=1, ReleaseDate=DateTime.Parse("14-06-1991"), RunTime=143 },
                    new Movie { Title="The Haunted", Director="Robert Mandel",
                       Genre=1, ReleaseDate=DateTime.Parse("06-05-1991"), RunTime=100 },
                    new Movie { Title="Old School", Director="Todd Phillips",
                       Genre=0, ReleaseDate=DateTime.Parse("21-02-2003"), RunTime=91 },
                    new Movie { Title="Anchorman: The Legend of Ron Burgundy",
                       Director="Adam McKay", Genre=0,
                       ReleaseDate=DateTime.Parse("09-07-2004"), RunTime=94 },
                    new Movie { Title="Bruce Almighty", Director="Tom Shadyac",
                       Genre=0, ReleaseDate=DateTime.Parse("23-05-2003"), RunTime=101 },
                    new Movie { Title="Ace Ventura: Pet Detective", Director="Tom Shadyac",
                       Genre=0, ReleaseDate=DateTime.Parse("04-02-1994"), RunTime=86 },
                    new Movie { Title="Goonies", Director="Richard Donner",
                       Genre=0, ReleaseDate=DateTime.Parse("07-06-1985"), RunTime=114 },
                    new Movie { Title="Sixteen Candles", Director="John Hughes",
                       Genre=1, ReleaseDate=DateTime.Parse("04-05-1984"), RunTime=93 },
                    new Movie { Title="The Breakfast Club", Director="John Hughes",
                       Genre=1, ReleaseDate=DateTime.Parse("15-02-1985"), RunTime=97 },
                    new Movie { Title="Pretty in Pink", Director="Howard Deutch",
                       Genre=1, ReleaseDate=DateTime.Parse("28-02-1986"), RunTime=96 },
                    new Movie { Title="Weird Science", Director="John Hughes",
                       Genre=0, ReleaseDate=DateTime.Parse("02-08-1985"), RunTime=94 },
                    new Movie { Title="Breakfast at Tiffany's", Director="Blake Edwards",
                       Genre=1, ReleaseDate=DateTime.Parse("05-10-1961"), RunTime=115 },
                     new Movie { Title="The Graduate", Director="Mike Nichols",
                       Genre=1, ReleaseDate=DateTime.Parse("02-04-1968"), RunTime=105 },
                    new Movie { Title="Dazed and Confused", Director="Richard Linklater",
                       Genre=0, ReleaseDate=DateTime.Parse("24-09-1993"), RunTime=103 },
                    new Movie { Title="Arthur", Director="Steve Gordon",
                       Genre=1, ReleaseDate=DateTime.Parse("25-09-1981"), RunTime=97 },
                    new Movie { Title="Monty Python and the Holy Grail",
                       Director="Terry Gilliam",
                       Genre=0, ReleaseDate=DateTime.Parse("10-05-1975"), RunTime=91 },
                    new Movie { Title="Dirty Harry", Director="Don Siegel",
                       Genre=2, ReleaseDate=DateTime.Parse("23-12-1971"), RunTime=102 }
                };
        }
    }
    public class Movie
    {
        private string _title = string.Empty;
        private string _director = string.Empty;
        private int _genre = 0;
        private int _runtime = 0;
        private DateTime _releaseDate = DateTime.MinValue;
        public string Title { get { return _title; } set { _title = value; } }
        public string Director { get { return _director; } set { _director = value; } }
        public int Genre { get { return _genre; } set { _genre = value; } }
        public int RunTime { get { return _runtime; } set { _runtime = value; } }
        public DateTime ReleaseDate { get { return _releaseDate; } set { _releaseDate = value; } }
        public string ReleaseDatestr { get { return _releaseDate.ToShortDateString(); } }
    }
    public class Methods
    {
        //public string GetPagination(
    }
