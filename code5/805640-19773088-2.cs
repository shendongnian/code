    public partial class _Default : System.Web.UI.Page
    {
    Database doDatabase = new Database();//custom class for querying a database
    ArrayList textboxNames = new ArrayList();//just to make life easier
    ArrayList pizzaNames = new ArrayList();//just to make life easier
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
            this.FillPizzaList();
    }
    private void FillPizzaList()
    {
        int count = 1;
        string query = "select FoodID, FoodName, 'R' + Convert(char(10), FoodPrice)[Food Price], rtrim(FoodDesc)[FoodDesc] from tblFood";
        doDatabase.Do_SQLQuery(query);
        Table tablePizza = new Table();
        TableRow tr = new TableRow();
        TableCell tc = new TableCell();
        for (int c = 0; c < 4; c++)
        {
            tc = new TableCell();
            if (c == 0)
            {
                tc.Width = new Unit("15%");
                tc.Text = "<h3>Pizza Name</h3>";
            }
            else if (c == 1)
            {
                tc.Text = "<h3>Pizza Description</h3>";
            }
            else if (c == 2)
            {
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.Width = new Unit("15%");
                tc.Text = "<h3>Pizza Price</h3>";
            }
            else if (c == 3)
            {
                 tc.Width = new Unit("12%");
                tc.Text = "<h3>Pizza Quantity</h3>";
            }
            tr.Cells.Add(tc);
        }
        tablePizza.Rows.Add(tr);
        
        foreach (DataRow dr in doDatabase.dataTbl.Rows)
        {
            tr = new TableRow();
            
            for (int c = 0; c < 4; c++)
            {
                tc = new TableCell();
                if (c == 0)
                {
                    pizzaNames.Add(dr["FoodName"].ToString());
                    tc.Text = dr["FoodName"].ToString();
                }
                else if (c == 1)
                {
                    tc.Text = dr["FoodDesc"].ToString();
                }
                else if (c == 2)
                {
                    tc.HorizontalAlign = HorizontalAlign.Center;
                    tc.Text = dr["Food Price"].ToString();
                }
                else if (c == 3)
                {
                    TextBox MyTextBox = new TextBox();
                    MyTextBox.ID = "Quantity" + count;
                    textboxNames.Add("Quantity" + count);
                    MyTextBox.Text = "0";
                    tc.Controls.Add(MyTextBox);
                    count++;
                }
                tr.Cells.Add(tc);
                
            }
            tablePizza.Rows.Add(tr);
        }
        pizzaMenu.Controls.Add(tablePizza);//add table to div
        
    }
