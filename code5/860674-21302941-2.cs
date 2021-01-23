    var list = new ListBox(); // I replace this with what?
    list.DataSource = cmd.ExecuteReader();
    
    foreach(object item in Listbox)
    {
       LinkButton btn = new LinkButton();
       btn.Text = item.name;
       btn.PostBackUrl = item.link;
       panel.Controls.Add(btn);
    }
    Controls.Add(panel);
