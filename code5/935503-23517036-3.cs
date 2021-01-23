    public partial class Form2: Form
    {       
        private Form1 objForm1;      
        public Form2(Form1 frm)
        {
            InitializeComponent();
            
            //get other form
            this.objForm1= frm;
            //call here public property of form1 which set controls properties within form1
            this.objForm1.SetReadOnly = true;
         }
    }
