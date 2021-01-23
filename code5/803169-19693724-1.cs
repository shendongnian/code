    //History class
    public partial class History : Form {
      //define this method to call explicitly before showing your History dialog
      public void LoadData(List<string> list){
        DataTable table = ConvertListToDataTable(list);
        dataGridView1.DataSource = table;
      }
      //other code ...
    }
    //Form1 (or Main Form) class
    private void showHistoryToolStripMenuItem_Click(object sender, EventArgs e) {
      using (History history = new History()) {
         history.LoadData(listH);// <---- call this first to load data
         history.ShowDialog();
         nonHomepage = URLInput.Text;
         if (String.IsNullOrEmpty(nonHomepage)) {
           return;
         } else {
           addToList(nonHomepage);
         }
      }
    }
