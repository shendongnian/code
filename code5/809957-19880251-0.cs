        private void Form1_Load(object sender, EventArgs e)
        {
            BindingList<Shift> bindingList = new BindingList<Shift>();           
            bindingList.Add(new Shift(ShiftType.SHIFT1));
            bindingList.Add(new Shift(ShiftType.SHIFT2));
            bindingList.Add(new Shift(ShiftType.SHIFT3));
            bindingList.Add(new Shift(ShiftType.SHIFT1));
            var ShiftColumn = new DataGridViewComboBoxColumn();
            dataGridView1.Columns.Add(ShiftColumn);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingList;
            ShiftColumn.DataPropertyName="shiftType";
            ShiftColumn.DataSource = new List<ShiftType> { ShiftType.SHIFT1, ShiftType.SHIFT2, ShiftType.SHIFT3 };
        }
       
    }
    class Shift
    {
        public ShiftType shiftType { get; set; }
        public Shift(ShiftType shiftType)
        {
            this.shiftType = shiftType;
           
        }
       
    }
    enum ShiftType
    {
        SHIFT1 ,
        SHIFT2,
        SHIFT3 
    }
