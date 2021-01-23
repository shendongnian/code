    public class TData
    {
        public String TText { get; set; }
        public UInt32 TValue { get; set; }
    }
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<TData> Data = new List<TData>
            {
                new TData{TText = "JSON", TValue = 0},
                new TData{TText = "C#", TValue = 1},
                new TData{TText = "JAVA", TValue = 2},
            };
            this.RadioButtonList1.DataTextField = "TText";
            this.RadioButtonList1.DataValueField = "TValue";
            this.RadioButtonList1.DataSource = Data;
            this.RadioButtonList1.DataBind();
        }
    }
