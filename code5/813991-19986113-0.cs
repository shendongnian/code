    public partial class Reports24Hours : Form
    {
        string category = "";
        public int WhichReciept = 0;
        public static List<ReportReciepts> recieptlist { get; set; } //Error here
        ...
    }
    
    
    
    public class ReportReciepts
    {
        public string[] Quantity { get; set; }
        public string[] ItemName { get; set; }
        public string[] Price { get; set; }
    }
