    public class Engin
    {
        public string ConnictionString = "Data Source=...";
        public Engin()
        {
            this.ConnictionString = "Data Source=...";
        }
    // [cut], usage:    
    public Engin myclass = new Engin();
    private void Form1_Load(object sender, EventArgs e)
    {
        // conn string also already set
        DataTable dt = myclass.Selecting_DT("Customer");
    }
