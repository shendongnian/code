    public partial class Form1 : Form
    {
        //setter Property
        public bool SetReadOnly
        {           
           set{ this.TextBox7.ReadOnly= value;}
           get{ return this.TextBox7.ReadOnly;}
        }
        //Form1 Constructor
        public Form1()
        {
             InitializeComponent();      
        } 
        //Form1 Load
        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 frm = new Form2(this);
            frm.Show();
        }  
     }
