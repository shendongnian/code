    public partial class Form1 : Form
    {
        List<seatArray> seatarray = new List<seatArray>();
        char test2;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 4; i++)
            {
                seatArray tmp = new seatArray();
                tmp.A = (char)(65+i);
                seatarray.Add(tmp);
            }
            listBox1.DataSource = seatarray;
            
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            using (Form2 f = new Form2())
            {
                f.SomeValue = 'T';
                f.ShowDialog();
                test2 = f.SomeValue;//test2 is char type variable
                seatarray[2].A = test2;//seat array A is a char type
                listBox1.DataSource = null; //remove your seatArray from your listbox's DataSource
                listBox1.DataSource = seatarray; //Reassign it
            }
        }
    }
    public class seatArray
    {
        public char A { get; set; }
        public override string ToString()
        {
            return A.ToString();
        }
    }
