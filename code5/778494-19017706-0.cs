    using System.Data;
    ...
    namespace WindowsFormsApplication1
    {
       
    
        public partial class Form1 : Form
        {
            DataTable dt;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
                dt = new DataTable();
                //load your table here
                ...
            }
            // Create an event (maybe via the designer) for button click...
            private void button1_Click(object sender, EventArgs e)
            {
                //you can reference the datatable here, for example tell how many rows it has
                MessageBox.Show(dt.Rows.Count.ToString());
                ...
            }
