    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string[] Lines = new string[10];
        private int CurrentRow = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Lines[i] = i.ToString("N2");
            }
            PrintDocument pd=new PrintDocument();
            PrintDialog pdi = new PrintDialog();
            pdi.ShowDialog();
            pd.PrinterSettings = pdi.PrinterSettings;
            pd.PrintPage += PrintTextBox;
            pd.Print();
        }
        private void PrintTextBox(object sender, PrintPageEventArgs e)
        {
            int y = 0;
            do 
            {
                e.Graphics.DrawString(Lines[CurrentRow],new Font("Calibri",10),Brushes.Black,new PointF(0,y));
                CurrentRow += 1;
                y += 20;
                if (y > 20) // max px per page
                {
                    e.HasMorePages = CurrentRow != Lines.Count(); // check if you need more pages
                    break;
                }
            } while(CurrentRow < Lines.Count());
        }
    }
