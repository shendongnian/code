    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void CompareWords(string a, string b)
        {
            List<string> diff;
            IEnumerable<string> set1 = a.Split(' ').Distinct();
            IEnumerable<string> set2 = b.Split(' ').Distinct();
            if (set2.Count() > set1.Count())
            {
                diff = set2.Except(set1).ToList();
            }
            else
            {
                diff = set1.Except(set2).ToList();
            }
            labelWrong.Text = ("Wrong words: " + diff.Count());
        }
        private void CompareChars(string a, string b)
        {
            List<string> diff = new List<string>();
            if (a == b) //Same string, no iteration needed.
                lblWrongChars.Text = ("Wrong chars: " + 0);
            if ((a.Length == 0) || (b.Length == 0)) //One is empty
            {
                lblWrongChars.Text = ("Wrong chars: " + (a.Length == 0 ? b.Length : a.Length));
            }
            double maxLen = a.Length > b.Length ? a.Length : b.Length;
            int minLen = a.Length < b.Length ? a.Length : b.Length;
            int sameCharAtIndex = 0;
            for (int i = 0; i < minLen; i++) //Compare char by char
            {
                if (a[i] == b[i])
                {
                    diff.Add(b[i].ToString() + ",");
                    sameCharAtIndex++;
                }
            }
            lblWrongChars.Text = ("Wrong chars: " + (a.Length - diff.Count()));
        }
        private void txtReadOnly_KeyDown(object sender, KeyEventArgs e)
        {
            string lastchar_inserted = e.KeyValue.ToString();
            if (lastchar_inserted == "32")
            {
                CompareWords(txtReadOnly.Text, txtUserType.Text);
            }
            CompareChars(txtReadOnly.Text, txtUserType.Text);
        }
    }
