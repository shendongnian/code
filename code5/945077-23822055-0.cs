    DataTable dt2 = InfoPCMS.db.executeSelectQuery("select * from Customer");
   
    foreach (DataRow row in dt2.Rows)
    {
        ComboboxItem newItem = newComboboxItem(row["id"], row["CustomerName"]);
        txtCustomer.Items.Add(newItem);
    }
    txtCustomer.Items.Insert(0,"Select a customer");
    txtCustomer.SelectedIndex = 0;
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public ComboboxItem(object val, string txt)
        {
            this.Value = val;
             this.Text = txt;
        }
        public override string ToString()
        {
            return Text;
        }
    }
