        private DateTimePicker cellDateTimePicker = new DateTimePicker();
        DateTimePicker[] sp = new DateTimePicker[100];
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt=new DataTable();
            dt.Columns.Add(new DataColumn("Start-Date", typeof(DateTime)));
            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
             
            sp[e.RowIndex] = new DateTimePicker();
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Start-Date")
            {
                this.cellDateTimePicker = sp[e.RowIndex];
                this.cellDateTimePicker.Format = DateTimePickerFormat.Time;
                    this.cellDateTimePicker.Name = "sp[" + e.RowIndex + "]";
             //   this.cellDateTimePicker.ValueChanged += new EventHandler(cellDateTimePickerValueChanged);
                this.cellDateTimePicker.Visible = true;
                this.cellDateTimePicker.CustomFormat = "dd/MM/yyyy";
                this.cellDateTimePicker.Format = DateTimePickerFormat.Custom;
                 this.dataGridView1.Controls.Add(cellDateTimePicker);
                System.Drawing.Rectangle tempRect = this.dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                cellDateTimePicker.Location = tempRect.Location;
                cellDateTimePicker.Width = tempRect.Width;
     dataGridView1.Columns[0].DefaultCellStyle.Format = "MM'/'dd'/'yyyy";
              this.cellDateTimePicker.Visible = true;
            }
        }
    }
