    public class ButtonCtrl : Button
    {
        public ButtonCtrl(int _arg1, int _arg2)
        {
            Arg1 = _arg1;
            Arg2 = _arg2;
        }
        public int Arg1 { get; set; }
        public int Arg2 { get; set; }         
    }
    //create buttons in form c'tor
        public Form1()
        {
            InitializeComponent();
            ButtonCtrl button1 = new ButtonCtrl(1,2);
            button1.Text = "dynamic 1";
            button1.Click += new EventHandler(button_click);
            button1.Top = 10;
            this.Controls.Add(button1);
            ButtonCtrl button2 = new ButtonCtrl(3, 4);
            button2.Text = "dynamic 2";
            button2.Click += new EventHandler(button_click);
            button2.Top = 30;
            this.Controls.Add(button2);
        }
