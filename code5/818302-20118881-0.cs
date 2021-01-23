    public Form1(){
      InitializeComponent();
      using (DBDataContext data = new DBDataContext()) {
        query = (from a in data.Programs
                 where a.IsCurrentApplication == 1
                 select a.Name).Distinct().ToList();//execute the query right 
      }
    }
    IEnumerable<string> query;
    private void comboBox1_DrawItem(object sender, DrawItemEventArgs e) {
        var combo = sender as ComboBox;
        e.DrawBackground();
        string text = combo.Items[e.Index].ToString();
        Brush brush = query.Contains(text) ? Brushes.Green : Brushes.Black;
        e.Graphics.DrawString(text, e.Font, brush, e.Bounds);
    }
