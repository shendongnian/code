    public partial class MyTopScreen : Form
    {
        public bool _myVariable ;
        public CommonForm _commonGridForm;
        public MyTopScreen(bool first_param, string second_param )
        {           
            CommonForm commonGridForm = new CommonForm(_myVariable);
            DataGridView dataGridView1 = commonGridForm.dataGridView1;
            _commonAttributForm = commonAttributForm;          
            InitializeComponent();
            this.TabPage1.Controls.Add(dataGridView1);
    
        }  
     } 
    public partial class CommonForm : Form
    {
            public CommonForm(bool _myVariable)
            {
               //Here you access the variable
            }
     }
