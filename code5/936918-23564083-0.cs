    public partial class Form1 : Form
    {
       readonly DataTable _data;
    
       public Form1()
       {
           InitializeComponent();
           // querying a database in a ctor is bad IMHO, but that's just example code
    	   _data = GetDataTable();
           dataGridView1.DataSource = _data.DefaultView;
       }
       
       private DataTable GetDataTable() {
            ...
       }
       
       private void DetailsFilter(string search, IEnumerable<string> columnNames)
       { 
           var filterString = String.Join(" AND ", columnNames.Select(c => String.Format("{0} LIKE '%{1}%'", c, search)));
    	   _data.DefaultView.RowFilter = filterString;
       }
    
       private void button1_Click(object sender, EventArgs e)
       {
           if (textBox1.Text == "" || textBox1.Text == String.Empty) 
    	   { 
    	   	    _data.Clear();
    	   }
           else
           {
               DetailsFilter(textBox1.Text.ToLower(), new []{"Description", "Category"});
           }
       }
    }
