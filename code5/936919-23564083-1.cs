    public partial class Form1 : Form
    {
       readonly DataTable _data;
    
       public Form1()
       {
           InitializeComponent();
           // querying a database in a ctor is bad IMHO, but that's just example code
           // keep a reference to the data once loaded
    	   _data = GetDataTable();
           // bind the gridview to the default DataView instead of the DataTable
           dataGridView1.DataSource = _data.DefaultView;
       }
       
       private DataTable GetDataTable() {
            ...
       }
       
       private void DetailsFilter(string search, IEnumerable<string> columnNames)
       { 
           // create the filter with AND and LIKE
           var filterString = String.Join(" AND ", columnNames.Select(c => String.Format("{0} LIKE '%{1}%'", c, search)));
    	   _data.DefaultView.RowFilter = filterString;
           // since the grid is bound the DataView, you immediately see the result
       }
    
       private void button1_Click(object sender, EventArgs e)
       {
           if (textBox1.Text == "" || textBox1.Text == String.Empty) 
    	   { 
           	   _data.DefaultView.RowFilter = String.Emtpy;
    	   }
           else
           {
               // note how we can pass column names
               DetailsFilter(textBox1.Text.ToLower(), new []{"Description", "Category"});
           }
       }
    }
