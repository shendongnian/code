    public partial class Form1 : Form
        {
            public Form1()
            {
              //code that you have already wrote 
              Form2 f2 = new Form2(dTable);
              f2.ShowDialog();
            }
         }
    public partial class Form2 : Form
        {
            public Form2(Datatable table)
            {
                //Do whatever you want with this table
                //Example 
                label1.Text = table.Rows[0][0].ToString();
            }
        }
