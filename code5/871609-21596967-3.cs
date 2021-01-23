    public partial class Test : System.Web.UI.Page {
      protected void Page_Load(object sender, EventArgs e) {
        if (!Page.IsPostBack) {
          var x = db.sp_GetAllProducts();
          DataList1.DataSource = x;
          DataList1.DataBind();
        }
      }
      protected void DataList1_ItemCommand(Object sender, DataListCommandEventArgs e) {
        String a = ((TextBox) e.Item.FindControl("tbName")).Text;
        String b = ((TextBox) e.Item.FindControl("tbDescription")).Text;
        ((Label) e.Item.FindControl("lUID")).Text = a + " " + b;
      }
    }
    public class db {
      public String UID { get; set; }
      public String name { get; set; }
      public String description { get; set; }
      public db(String UID, String name, String description) {
        this.UID = UID;
        this.name = name;
        this.description = description;
      }
      public static List<db> sp_GetAllProducts() {
        List<db> list = new List<db>();
        list.Add(new db("1", "1a", "1b"));
        list.Add(new db("2", "2a", "2b"));
        list.Add(new db("3", "3a", "3b"));
        list.Add(new db("4", "4a", "4b"));
        list.Add(new db("5", "5a", "5b"));
        list.Add(new db("6", "6a", "6b"));
        return list;
      }
    }
