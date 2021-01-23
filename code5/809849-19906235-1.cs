    public partial class Form1 : Form
    {
        //R E T R I E V E     B U T T O N 
        private void button3_Click(object sender, EventArgs e)
        {
          string recipeName = comboBox1.SelectedItem.ToString();
          Pop_up p = new Pop_up(recipeName, dset);
          p.Show();
        }
    }
