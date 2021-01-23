    public partial class Form2 : Form
    { 
       ComboBox comboBoxD; 
       ComboBox comboBoxType;
       public Form2(ComboBox cb, ComboBox cbType)
       {
            InitializeComponent();
            comboBoxD = cb;
            comboBoxType = cbType;
       }
       
       private void Form2_Load(object sender, EventArgs e)
       {
           
       }
       protected void buttonFinish_Click(object sender, EventArgs e)
       {           
            if(comboBoxD.Text == "Alphabet" && comboBoxType.Text == "Numbers")
            {
            }
       }
    }
