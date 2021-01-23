    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var list = new List<Thing>
                {
                    new Thing() {ID = 1, Name = "Bob"},
                    new Thing() {ID = 2, Name = "Geraldine"}
                };
            gridMe.DataSource = list;
            gridMe.DataBind();
        }
    }
    public class Thing
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
