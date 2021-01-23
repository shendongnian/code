    MySqlDataAdapter DA = new MySqlDataAdapter();
    string sqlSelectAll = "SELECT * from lieferanten";
    DA.SelectCommand = new MySqlCommand(sqlSelectAll, CO);
    DA.Fill(DTL);
    string sqlSelectOrte = "SELECT DISTINCT ort from lieferanten";
    DA.SelectCommand = new MySqlCommand(sqlSelectOrte, CO);
    DA.Fill(DTO);
    ortsListe = DTO.AsEnumerable().Select(r => r["ort"].ToString())
                .OrderBy(r => r).Select(r => new StringClass(r)).ToList();
    BindingSource bSource = new BindingSource();
    bSource.DataSource = DTL;
    dgv_Lief.AutoGenerateColumns = false;
    DataGridViewCell  dct = new DataGridViewTextBoxCell();
    DataGridViewColumn dc0 = new DataGridViewColumn();
    dc0.ValueType = typeof(int);
    dc0.Name = "lieferanten_key";
    dc0.DataPropertyName = "lieferanten_key";
    dc0.CellTemplate = dct;
    dgv_Lief.Columns.Add(dc0);
    DataGridViewColumn dc1 = new DataGridViewColumn();
    dc1.ValueType = typeof(string);
    dc1.Name = "name";
    dc1.CellTemplate = dct;
    dc1.DataPropertyName = "firma";
    dgv_Lief.Columns.Add(dc1);
    DataGridViewComboBoxCell dccb = new DataGridViewComboBoxCell();
    dccb.DataSource = ortsListe;
    dccb.DisplayMember = "theString";  // using the same field..
    dccb.ValueMember   = "theString";  // .. as I have only one
    DataGridViewColumn dc2 = new DataGridViewColumn();
    dc2.ValueType = typeof(string);
    dc2.DataPropertyName = "ort";
    dc2.CellTemplate = dccb;
    dgv_Lief.Columns.Add(dc2);
    dgv_Lief.DataSource = bSource;
