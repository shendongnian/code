    public partial class testForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        [WebMethod]
        public static void PostData(List<MyClass> myCollection)
        {
            Console.WriteLine(myCollection.Count);
        }
    }
    public class MyClass
    {
        string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        string option;
        public string Option
        {
            get { return option; }
            set { option = value; }
        }
        string date;
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
    }
