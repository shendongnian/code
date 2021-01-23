        public partial class Form1 : Form
        {
            List<int> exes = new List<int> { 1, 3, 7, 9 };
            List<int> whys = new List<int> { 10, 20, 30, 40 };
            public Form1()
           {
                InitializeComponent();
                chart1.Series[0].Points.DataBindXY(exes, whys);
           }
           private void button1_Click(object sender, EventArgs e)
          {
               exes.Add(13);
               whys.Add(50);
               chart1.Series[0].Points.DataBindXY(exes, whys);            
          }
       ...
