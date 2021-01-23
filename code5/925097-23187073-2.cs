    public partial class Form1 : Form
    { 
        DataTable tableEC0 = new DataTable(); // central table 
    
        public Form1()
        {
            InitializeComponent();
            // initialize your table with the columns needed
            tableEC0.Columns.Add("Nome", typeof(string));
            tableEC0.Columns.Add("valor", typeof(string));
            
            // hookup textbox
            readG.TextChanged += readG_TextChanged;
            readQ.TextChanged += readQ_TextChanged;
            readW.TextChanged += readW_TextChanged;
        } 
        // refactored to one call
        private void button12_Click(object sender, EventArgs e)
        {      
            UpdateAll();
        }
        // hookup this method to the TextBox_Changed event 
        private void readG_TextChanged(object sender, EventArgs e)
        {
            Update("G", (TextBox) sender);
        }
        private void readQ_TextChanged(object sender, EventArgs e)
        {
            Update("Q", (TextBox) sender);
        }
        private void readW_TextChanged(object sender, EventArgs e)
        {
            Update("W", (TextBox) sender);
        }
        // update all values
        private void UpdateAll()
        {
            Update("G", readG.Text);
            Update("Q", readQ.Text);
            Update("W", readW.Text);
            Update("Tipodeverificacao", tipodeverificacao);
        }
        // update from a textbox event
        private void Update(string key, TextBox txtBox)
        {
             Update(key, txtBox.Text);
        }
      
         // update (or insert in new) a row in your table
         private void Update(string key, string value)
         {
            // find a row
            var rows = tableEC0.Select(
                       String.Format("'Nome'='{0}'", key));
            if (rows.Length==1)  
            {
                 // found, update
                 rows[0]["valor"]= value;
            } 
            else if(rows.Length > 1)
            {
                 throw new Exception("huh? too many rows found");
            }
            else
            {
                 // not found, add
                  tableEC0.Rows.Add(key, value);
            }
         }
    }
