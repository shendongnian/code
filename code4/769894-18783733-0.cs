    public partial class Form2 : Form
    {
        public List<string> f2List = new List<string>();
    
        private void button1_Click(object sender, EventArgs e)
        {
            f2List.Add(f2List.Count.ToString());
        }
    }
