    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            List<NameVersion> lst = new List<NameVersion>();
            lst.Add(new NameVersion("name_1.2.3"));
            lst.Add(new NameVersion("name_1.20.3"));
            lst.Sort(delegate(NameVersion x, NameVersion y) 
            {
                int i = x.a.CompareTo(y.a);
                if (i == 0)
                    i = x.b.CompareTo(y.b);
                if (i == 0)
                    i = x.c.CompareTo(y.c);
                return i;
            });
        }
    }
    
    public class NameVersion
    {
        public string Name = "";
        public int a, b, c;
        public NameVersion(string text)
        {
            Name = text;
            string[] sa = text.Split('_');
            string[] sb = sa[1].Split('.');
            a = Convert.ToInt32(sb[0].PadRight(3, '0'));
            b = Convert.ToInt32(sb[1].PadRight(3, '0'));
            c = Convert.ToInt32(sb[2].PadRight(3, '0'));
        }
    }
