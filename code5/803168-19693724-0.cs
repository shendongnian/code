    public partial class History : Form {
      public History(){
        InitializeComponent();
      }
      public Form1 MainForm {get;set;}
      private void History_Load(object sender, EventArgs e) {     
        var list = MainForm == null ? new List<string>() : MainForm.listH;
        DataTable table = ConvertListToDataTable(list);
        dataGridView1.DataSource = table;
      }
      //other code ....
    }
    //Form1 class
    private void showHistoryToolStripMenuItem_Click(object sender, EventArgs e) {
      //note the MainForm initialization using Property initializer
      using (History history = new History {MainForm = this}) {
        history.ShowDialog();
        nonHomepage = URLInput.Text;
        if (String.IsNullOrEmpty(nonHomepage)) {
          return;
        } else {
          addToList(nonHomepage);
        }
      }
    }
