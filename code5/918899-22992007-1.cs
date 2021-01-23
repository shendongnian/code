    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        public void WriteAndWait(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(1000);
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                WriteAndWait("Creating output file that is 6014P x 4988L.");
                WriteAndWait("Processing input file [FileName].tiff.");
                WriteAndWait("Using band 4 of source image as alpha. ");
                WriteAndWait("Using band 4 of destination image as alpha.");
    
                for (int k = 0; k <= 100; k += 10)
                {
                    Console.Write(k.ToString() + "...");
                    Thread.Sleep(1000);
                }
            }).Start();
        }
    }
