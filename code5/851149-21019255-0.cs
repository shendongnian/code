    private void GenerateButton_Click(object sender, EventArgs e)
        {
            BindingList<ListType> SerialNumberList = new BindingList<ListType>();
            SerialNumberList.Add(new ListType("Hello"));
            
            dataGridView1.DataSource = SerialNumberList;
          
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
