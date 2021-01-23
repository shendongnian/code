    public partial class Form1 : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            List<string> f1List = f2.f2List;
        }
