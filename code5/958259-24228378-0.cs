    public class MyTabPage : TabPage
    {
        private Button bttn1;
        public event EventHandler Button1Clicked;
        public MyTabPage()
        {
            bttn1 = new Button();
            bttn1.Name = "button1";
            bttn1.Text = "Start";
            bttn1.Location = new Point(3, 405);
            bttn1.Size = new Size(75, 23);
            bttn1.Click += bttn1_Click;
            this.Controls.Add(bttn1);
        }
        void bttn1_Click(object sender, EventArgs e)
        {
            OnButton1Clicked();
        }
        protected virtual void OnButton1Clicked()
        {
            var h = Button1Clicked;
            if (h != null)
                h(this, EventArgs.Empty);
        }
    }
