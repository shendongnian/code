    public partial class Form1 : Form
    {
        Int32 t = 6;
        Int32 J = 10;
        public Form1()
        {
            InitializeComponent();
            Random rand1 = new Random();
            Int32 Fight = rand1.Next(1, 11);
            label4.Text = Convert.ToString(J);
            if (Fight <= t)
                label3.Text = Convert.ToString(J);
            else
                txtDialogBox.Text = ("No Fight in this room");
        }
        private void Attack_Click(object sender, EventArgs e)
        {
            Random rand2 = new Random();
            Int32 Attack = rand2.Next(1, 4);
            Int64 y = 1;
            //opponents hp bar goes down by 1
            J--;
            label3.Text = Convert.ToString(J);
            // chance for your hp bar to go down
            if (Attack >= y)
            {
                label4.Text = Convert.ToString(t);
                t--;
            }
        }
    }
