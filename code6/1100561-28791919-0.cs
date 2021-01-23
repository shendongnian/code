     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void CompareStrings()
            {
                List<string> diff;
                IEnumerable<string> set1 = txtReadOnly.Text.Split(' ').Distinct();
                IEnumerable<string> set2 = txtUserType.Text.Split(' ').Distinct();
    
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
    
            private void txtReadOnly_KeyDown(object sender, KeyEventArgs e)
            {
                string lastchar_inserted = e.KeyValue.ToString();
                
                // If space = lastchar, compare strings
                if (lastchar_inserted == "32")
                {
                    CompareStrings();
                }
            }
        }
