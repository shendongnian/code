    public partial class Form1 : Form
    { 
        DataTable tableEC0 = new DataTable(); // central table 
    
        public Form1()
        {
            InitializeComponent();
            // initialize your table with the columns needed
            tableEC0.Columns.Add("Nome", typeof(string));
            tableEC0.Columns.Add("valor", typeof(string));
        } 
        // refactored to one call
        private void button12_Click(object sender, EventArgs e)
        {      
            UpdateAll();
        }
        // hookup this method to the TextBox_Changed event 
        // this updates the tables as soon as the text changes
        // you copy thisd method for the other textboxes
        // changing the G to Q, W or Tipodeverificacao
        private void readG_TextChanged(object sender, EventArgs e)
        {
            Update("G", (TextBox) sender);
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
                 throw new Exception("huh? to many rows found");
            }
            else
            {
                 // not found, add
                  tableEC0.Rows.Add(key, value);
            }
         }
    }
