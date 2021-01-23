    //1) On the source page with the search box, you would redirect the user 
    //     to the search results page and append the search query to the URL: 
    Response.Redirect("search.aspx?search=" + HttpUtility.UrlEncode(query));
    //2) On the search results page, parse the query string values
    String searchQuery = Request.QueryString["search"];
    //3) Perform your search action in code and display the results.
    protected void btnSubmit_Click(object sender, EventArgs e){
        //your search code
        using (ELibraryEntities entities = new ELibraryEntities())
        {
            var search = from books in entities.Reviews
                    where books.Title.Contains(searchQuery)
                    select books;
            ListView1.DataSource = search;
            ListView1.DataBind();
        }
    }
