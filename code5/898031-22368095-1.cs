    public class MyClass
    {
        public string FriendlyValue { get; set; }
        public string RealValue { get; set; }
    }
    public class YourForm : Form
    {
        public YourForm()
        {
            var friendlyList
                = new List<string>();  // imagine it's populated with friendly values
            foreach (var fv in friendlyList)
            {
                checkedListBox1.Items.Add(
                    new MyClass { FriendlyValue = fv, RealValue = ??? });
            }
            checkedListBox1.DisplayMember = "FriendlyValue";
            checkedListBox1.ValueMember = "RealValue";        
        }
    }
