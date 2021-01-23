        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
        
                private Image first;
                private Image reitmi;
                private Image reitmi2;
                private Image selectForCancel;
        
     private void Form2_Load(object sender, EventArgs e)
                {
                 
                    first = Properties.Resources.Open;
                    reitmi = Properties.Resources.Select;
                    reitmi2 = Properties.Resources.Reserve;
                 
        
        
                    pictureBox1.Image = Properties.Resources.Open;
                   
        }
    
    private void pictureBox2_Click(object sender, EventArgs e)
            {    
            if (pictureBox2.Image == first)
                    {
                        pictureBox2.Image = reitmi;
                      
                        listHoldingSeats.Items.Add("B1");
                        txtListCount.Text =listHoldingSeats.Items.Count.ToString();
                       
                    }
        
        
                    else
                    {
                        pictureBox2.Image = first;
                        listCancelledList.Items.Add("B1");
                    } 
        
        
            }
        
         
