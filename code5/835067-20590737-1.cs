    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    
    public partial class TestListView : System.Web.UI.Page
    {
    	protected void Page_Load(object sender, EventArgs args)
    	{
    	    if (!IsPostBack)
    	    {
    	        var books = new List<Book>
    	        {
    	            new Book {Title = "Book 1"},
    	            new Book {Title = "Book 2"},
    	            new Book {Title = "Book 3"}
    	        };
    	        ListView1.DataSource = books;
    	        ListView1.DataBind();
    	    }
    	}
    
    	protected void btnChange_Command(object sender, CommandEventArgs e)
    	{
    		Page.Title = e.CommandName;
    	}
        
    }
    
    public class Book
    {
    	public string Title { get; set; }
    }
