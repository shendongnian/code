    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string blab = "blabllabnsdfsdfsd";
            string blab2 = blab.Chunk("-", 4);
            Console.WriteLine(blab);
            Console.WriteLine(blab2);
        }
    }
    public static class Extensions
    {
        public static string Chunk(this String str, string separator, int groupsOf)
        {
            string[] chunks = System.Text.RegularExpressions.Regex
                .Matches(str, ".{1," + groupsOf.ToString() + "}")
                .OfType<System.Text.RegularExpressions.Match>()
                .Select(s => s.ToString())
                .ToArray();
            return String.Join(separator, chunks);
        }
    }   
