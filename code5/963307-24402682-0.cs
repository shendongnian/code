    public class Record {
            public Record(int id) {
                this.Id = id;
                this.Data = string.Format("Record {0}", id);
            }
            public int Id { get; set; }
            public string Data { get; set; }
        }
    
        public partial class Form1: Form {
            public Form1() {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e) {
    
                BindingList<Record> dataSource = new BindingList<Record>();
                gridControl1.DataSource = dataSource;
                for(int i = 0; i < 10; i++)
                    dataSource.Add(new Record(i));
            }
        }
     
