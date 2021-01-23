    namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                    //string unconverted = "äüö"; // is what you get when using File.ReadAllText(file)
                    string unconverted = text;
                    byte[] converted = Encoding.Unicode.GetBytes(unconverted);
                    converted = converted.Where(x => x != 0).ToArray(); //skip bytes that are 0
                    foreach (var item in converted)
                    {
                        Console.WriteLine(item);
                        memoEdit1.Text =  memoEdit1.Text + item.ToString();
                        memoEdit1.Text = memoEdit1.Text + " "; //just for the Look and Feel :)
                    }
                   // memoEdit1.Text = text;
                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
        }
    }
