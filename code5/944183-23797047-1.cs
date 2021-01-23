    public partial class Form1 : Form
    {
        static Seats[] seatArray = new Seats[15];
        char test2;
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < seatArray.Length-1; i++)
            {
                Seats tmp = new Seats();
                tmp.A = (char)(65+i);
                seatArray[i] = tmp;
            }
            
            listBox1.DataSource = seatArray;
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            using (Form2 f = new Form2())
            {
                f.SomeValue = 'T';
                f.ShowDialog();
                test2 = f.SomeValue;//test2 is char type variable
                seatArray[2].A = test2;//seat array A is a char type
                listBox1.DataSource = null; //remove array from the listbox's datasource
                listBox1.DataSource = seatArray; //reassign it to it.
            }
        }   
       
    }
    public class Seats
    {
        public char A { get; set; }
        public override string ToString()
        {
            return A.ToString();
        }
    }
