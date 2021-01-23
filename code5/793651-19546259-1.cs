        protected void Page_Load(object sender, EventArgs e)
        {
            BindAuthorGrid();
        }
        protected void btnFindAuthor_Click(object sender, EventArgs e)
        {           
            BindAuthorGrid();
        }
        private void BindAuthorGrid()
        {
            //Bind search results to AuthorGridView control
            gvAuthors.DataSource = SearchAuthor(txtFindAuthor.Text);
            gvAuthors.DataBind();
        }
        private DataTable SearchAuthor(string authorName)
        {
            var searchResultsTable = new DataTable();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Libros"].ConnectionString))
            {
                try
                {   
                    var cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    if (authorName != string.Empty)
                    {
                        cmd.CommandText = "SELECT * FROM Authors WHERE AuthorName = @authorName ORDER BY AuthorName ASC";
                        cmd.Parameters.AddWithValue("authorName", authorName);
                    }
                    else
                    {
                        cmd = new SqlCommand("SELECT * FROM Authors", conn);
                    }
                    //create sql adapter by passing command object
                    var adapter = new SqlDataAdapter(cmd);
                    //fill the search results table
                    adapter.Fill(searchResultsTable);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }
            return searchResultsTable;
        }
