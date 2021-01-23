    [DataContract]
    public class ViewModel {
      [DataMember]
      public string FirstEmail { get; set; }
      [DataMember]
      public IList<EmailModel> Items { get; set; }
   
      public ViewModel() {
        Items = new List<EmailModel>();
      }
    }
    [DataContract]
    public class EmailModel {
      [DataMember]
      public string Email { get; set; }
      [DataMember]
      public int Index { get; set; }
    }
    public partial class Default : System.Web.UI.Page {
      protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
          var serializer = new DataContractJsonSerializer(typeof(ViewModel));
          using (var stream = new MemoryStream()) {
            serializer.WriteObject(stream, new ViewModel());
            hfClientModel.Value = Encoding.UTF8.GetString(stream.ToArray());
          }
        }
      }
      protected void btnSave_Click(object sender, EventArgs e) {
        var serializer = new DataContractJsonSerializer(typeof(ViewModel));
        ViewModel viewModel;
        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(hfClientModel.Value), false)) {
          viewModel = (ViewModel)serializer.ReadObject(stream);
        }
        // enjoy viewModel
      }
    }
