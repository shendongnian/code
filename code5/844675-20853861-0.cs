    class Myform :Form
    {
        private Label lText;
        private Button BTN_OK;
        public Myform()
        {
            lText = new Label();
            BTN_OK = new Button();
            this.Width = 600;
            this.Height = 400;
            this.BackColor = Color.White;
            this.Icon = new Icon("D:\\Icon1.ico");
            this.Text = "Stay Brutal";
            //--Button properties
            //***************************
            EventHandler eh1 = new EventHandler(OnClick);
            BTN_OK.Click += eh1;
            BTN_OK.Text = "Agree";
            BTN_OK.Location = new Point(200, 200);
            BTN_OK.BackColor = Color.Tomato;
            //***************************
            //--Label properties
            lText.Text = "Question";
            lText.TextAlign = ContentAlignment.MiddleCenter;
            lText.ForeColor = Color.Blue;
            lText.Location = new Point(100, 200);
            lText.BackColor = Color.Tomato;
            //**************************
            this.Controls.Add(lText);
            this.Controls.Add(BTN_OK);
        }
