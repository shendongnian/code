    HtmlContainerControl Container = new HtmlGenericControl("li");
    //set it's style etc 
    //use button class and add it in Container 
    Button b=new Button();
    b.Click += new EventHandler(b_Click);
    //set it's property an on click event
    //add it to li;
    Container.Controls.Add(b);
    Label1.Controls.Add(container);
    protected void b_Click(object sender, EventArgs e)
    {
        //Your process you want to do on click.
    }
