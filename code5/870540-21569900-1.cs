    public partial class Form1 : Form
    {
        int count =1;
        public Form1()
        {
            InitializeComponent();
        }
        private void mcc_MyCustomClickEvent(object sender, EventArgs e)
        {
            ((MyCustomUserControl)sender).CheckBoxValue = !((MyCustomUserControl)sender).CheckBoxValue;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MyCustomUserControl mcc = new MyCustomUserControl();
            mcc.MyCustomClickEvent+=mcc_MyCustomClickEvent;
            mcc.Name = "mmc" + count.ToString();
            mcc.SetCaption = "Your Text Here";
            flowLayoutPanel1.Controls.Add(mcc);
            count += 1;
        }
        var temp = this.Controls.Find("mmc1", true);
        if (temp.Length != 0)
        {
            var uc = (MyCustomUserControl)temp[0];
            uc.SetCaption = "Found Me";
        }    
    }
