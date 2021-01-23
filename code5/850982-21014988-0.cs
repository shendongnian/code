    protected void Btn_publicpost_Click(object sender, ImageClickEventArgs e)
    {
       var box = (TextBox)((ImageButton)sender).Parent.FindControl("txt_publicpost");
       string x = box.Text;
    }
