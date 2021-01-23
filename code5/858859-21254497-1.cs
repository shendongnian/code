    Load(){ //Page load
    if(!Page.IsPostBack){ // skips the execution of below lines during the next time.
     string m = DateTime.Now.ToString("MMMM");
            string y = DateTime.Now.Year.ToString();
            DropDownList1.Items.Add(m + " " + y);
            if (DateTime.Now.AddMonths(1).Month.ToString().Equals("January"))
                y = DateTime.Now.AddYears(1).Year.ToString();
            DropDownList1.Items.Add(DateTime.Now.AddMonths(1).ToString("MMMM") + " " + y);
            if (DateTime.Now.AddMonths(2).Month.ToString().Equals("January"))
                y = DateTime.Now.AddYears(1).Year.ToString();
            DropDownList1.Items.Add(DateTime.Now.AddMonths(2).ToString("MMMM") + " " + y);
            if (DateTime.Now.AddMonths(3).Month.ToString().Equals("January"))
                y = DateTime.Now.AddYears(1).Year.ToString();
            DropDownList1.Items.Add(DateTime.Now.AddMonths(3).ToString("MMMM") + " " + y);
            if (DateTime.Now.AddMonths(4).Month.ToString().Equals("January"))
                y = DateTime.Now.AddYears(1).Year.ToString();
            DropDownList1.Items.Add(DateTime.Now.AddMonths(4).ToString("MMMM") + " " + y);
            if (DateTime.Now.AddMonths(5).Month.ToString().Equals("January"))
                y = DateTime.Now.AddYears(1).Year.ToString();
            DropDownList1.Items.Add(DateTime.Now.AddMonths(5).ToString("MMMM") + " " + y);
             string date = DropDownList1.SelectedItem.Text;
            connect con = new connect(date);
            IList<connect.Session> records = con.getToken();
            GridView1.DataSource = records;
     }}
