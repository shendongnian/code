    //This is used as CellTemplate for your interested column
    public class TrackedValueDataGridViewCell : DataGridViewTextBoxCell {
        public object OldValue { get; set; }
        protected override bool SetValue(int rowIndex, object value) {
          OldValue = Value;                
          return base.SetValue(rowIndex, value);
        }
    }
    public partial class Form1 : Form {
      public Form1(){
        InitializeComponent();
        //init your grid
        dataGridView1.DataSource = yourDataSource;
        dataGridView1.Columns["sumColumn"].CellTemplate = new TrackedValueDataGridViewCell();
        sum = InitSum(dataGridView1,"sumColumn");
        textBox9.Text = sum.ToString();
        dataGridView1.CellValueChanged += (s,e) => {
          if(dataGridView1[e.ColumnIndex,e.RowIndex].Name != "sumColumn") return;
          var cell = ((TrackedValueDataGridViewCell) dataGridView1[e.ColumnIndex, e.RowIndex]);
          sum -= ((double?) cell.OldValue).GetValueOrDefault();
          sum += ((double?)cell.Value).GetValueOrDefault();
          textBox9.Text = sum.ToString();
        };
        
      }
      double sum;
      public double InitSum(DataGridView grid, string colName) {
          return grid.Rows.OfType<DataGridViewRow>()                       
                     .Sum(row => ((double?) row.Cells[colName].Value).GetValueOrDefault());
      }
    }
