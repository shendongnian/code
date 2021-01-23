    public class Engin
    {
        public string ConnictionString = "Data Source=...";
        public string database;
    // [cut], usage:    
    public Engin myclass = new Engin();
    private void Form1_Load(object sender, EventArgs e)
    {
        // conn string already set
        DataTable dt = myclass.Selecting_DT("Customer");
    }
