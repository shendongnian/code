       protected void Page_Load(object sender, EventArgs e)
    {
        ListItem item;
        int i = 0;
        System.IO.FileInfo file;
     
        var Images =
            from n in System.IO.Directory.GetFiles(Server.MapPath("Images"))
            orderby n descending
            select n;
     
        foreach (var filename in Images)
        {
            file = new System.IO.FileInfo(filename);
           
            item = new ListItem("<img src='" + "Images/" + file.Name + "' alt='" + file.Name +
                "' title='"+file.Name+"'/>", i.ToString());
         
            RadioButtonList1.Items.Add(item);
            RadioButtonList1.CellPadding = 5;
            RadioButtonList1.CellSpacing = 5;
            i++;
        }
    }
    
    
        <div>
        <asp:RadioButtonList ID="RadioButtonList1"
            runat="server"
            BorderStyle="Groove"
            BorderWidth="1px"
            RepeatColumns="3"
            RepeatLayout="Table">
        </asp:RadioButtonList> 
    </div>
