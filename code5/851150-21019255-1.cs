    protected void GenerateButton_Click(object sender, EventArgs e)
        {
            BindingList<ListType> SerialNumberList = new BindingList<ListType>();
            int x = 5;
            SerialNumberList.Add(new ListType(x.ToString()));
            grid.DataSource = SerialNumberList;
            grid.DataBind();
        }
    }
    public class ListType
    {
        private string Itemname;
        public ListType(string _ListItem)
        {
            ListItem = _ListItem;
        }
        public string ListItem
        {
            get { return Itemname; }
            set { Itemname = value; }
        }
    }
