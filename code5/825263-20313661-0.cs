    Page_Load()
    {
       Button b = new Button();
       b.ID = topic.Topic_Id + "_1"; // topic_Id is my unique ID for each topic on the blog
       b.Text = "Edit";
       b.ToolTip = "Edit";
       b.CommandArgument = b.ID; //passing this to event handler
       b.Command += new CommandEventHandler(b_Command); //handler
    }
    void b_Command(object sender, CommandEventArgs e)
    {
        System.Windows.Forms.MessageBox.Show(e.CommandArgument.ToString());
    }
