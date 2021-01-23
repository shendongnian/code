    public partial class Form1 : Form
    {
        LinkedList<String> myList = new LinkedList<String>();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                Button b = new Button() { Height = 30, Width = 70, Location = new Point(i, 50 * i),Name = "NewButton" + (i + 1).ToString() , Tag=i};
                b.Click += b_Click;
                this.Controls.Add(b);
            }
        }
        void b_Click(object sender, EventArgs e)
        {
           Button b = (Button)sender;
            if(myList.Contains(b.Name)) //Check if button is in the List then Change Picture and remove
            {
                b.BackgroundImage = Properties.Resources.Peg_Blue;
                myList.Remove(b.Name);
            }
            else
            {
                b.BackgroundImage = Properties.Resources.Peg_Red;
                myList.AddLast(b.Name);
            }
                
        }
    }
