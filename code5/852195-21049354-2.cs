    public class Engin
    {
        public string ConnictionString;
        public string database;
        public void InitConnString()
        {
            this.ConnictionString = "Data Source=...";
        }
    // [cut], usage:    
    public Engin myclass = new Engin();
    private void Form1_Load(object sender, EventArgs e)
    {
        myclass.InitConnString();
       DataTable dt = myclass.Selecting_DT("Customer");
    }
   
