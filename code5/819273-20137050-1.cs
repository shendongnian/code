    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebDemo.WebForm1" %>
    
    <%@ Register src="MoviePanel.ascx" tagname="MoviePanel" tagprefix="uc1" %>
    
    <!DOCTYPE html>
    
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
    <body>
        <form id="form1" runat="server">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <uc1:MoviePanel runat="server" mymovieid='<% #Eval("MovieID") %>'
                        mymoviename='<% #Eval("movieName") %>'
                        mymoviedescription='<% #Eval("movieDescription") %>'
                        id="MovieDetailPanel1" />
                </ItemTemplate>
            </asp:Repeater>
        </form>
    </body>
    </html>
    
    
    namespace WebDemo
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
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
        }
    }
    
    <%@ Control Language="C#" AutoEventWireup="true"
        CodeBehind="MoviePanel.ascx.cs" Inherits="WebDemo.MoviePanel" %>
    
    <p>
        <strong>Inside Control</strong>:
        <asp:Label ID="MovieIDLbl" runat="server" />
        <asp:Label ID="MovieNameLbl" runat="server" />
        <asp:Label ID="DescriptionLbl" runat="server" />
    </p>
    
    namespace WebDemo
    {
        public partial class MoviePanel : System.Web.UI.UserControl
        {
            public int myMovieID { get; set; }
            public string myMovieName { get; set; }
            public string myMovieDescription { get; set; }
    
            protected void Page_Load(object sender, EventArgs e)
            {
                MovieIDLbl.Text = myMovieID.ToString();
                MovieNameLbl.Text = myMovieName;
                DescriptionLbl.Text = myMovieDescription;
            }
        }
    }
