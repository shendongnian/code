    //the Form1 class
    public partial class Form1 : Form {
      Form2 f2 = new Form2();  
      public Form1(){
        InitializeComponent();
        f2.TransferSelectedRows += (s,e) => {
           foreach(DataGridViewRow row in dataGridView1.SelectedRows){
             //add the selected row to the receiver grid
             e.ReceiverGrid.Rows.Add(row.Cells.OfType<DataGridViewCell>()
                                              .Select(cell=>cell.Value).ToArray());
             //remove the selected row
             dataGridView1.Rows.Remove(row);
           }
        };
      }     
    }
    //Form2 class
    public partial class Form2 : Form { 
      public Form2() {
        InitializeComponent();       
      }
      public class TransferSelectedRowsEventArgs : EventArgs {
        public DataGridView ReceiverGrid {get; private set;}
        public TransferSelectedRowsEventArgs(DataGridView receiver){
           ReceiverGrid = receiver;
        }
      }
      public delegate void TransferSelectedRowsEventHandler(object sender, TransferSelectedRowsEventArgs e);
      public event TransferSelectedRowsEventHandler TransferSelectedRows;
      protected virtual void OnTransferSelectedRows(TransferSelectedRowsEventArgs e){
        TransferSelectedRowsEventHandler handler = TransferSelectedRows;
        if(handler != null) handler(this, e);
      }
      //Click event handler for button1
      private void button1_Click(object sender, EventArgs e){
        OnTransferSelectedRows(new TransferSelectedRowsEventArgs(dataGridView1));
      }
    }
