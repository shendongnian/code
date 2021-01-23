    private TextBox ctb_AuthorName;
    private TextBox ctb_AuthorLastName;
    ...
    this.ctb_AuthorName = new TextBox();
    this.ctb_AuthorLastName = new TextBox();
    ...
    
    private void cbtn_CreateNewAuthor_Click(object sender, EventArgs e)
    {
        using (var db = new ProgramContext())
        { 
            var author = new Author(ctb_AuthorName.Text, ctb_AuthorLastName.Text);
            ...
        }
    }
