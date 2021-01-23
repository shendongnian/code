    public List<SavedSettings> Settings { get; set; }
    private void ReadXML()
    {
      System.Xml.Serialization.XmlSerializer reader =
          new System.Xml.Serialization.XmlSerializer(typeof(List<SavedSettings>));
      if (File.Exists(@"SavedSettings.xml"))
      {
        System.IO.StreamReader file = new System.IO.StreamReader(
          @"SavedSettings.xml");
        this.Settings = (List<SavedSettings>)reader.Deserialize(file);
        file.Close();
      }
    }
    private void LoadDGV()
    {
      this.ReadXML();
      if (this.Settings != null)
      {
        // This assumes your dgv has added columns already.
        int rows = this.Settings.Count / this.dataGridView1.Columns.Count;
        int cols = this.dataGridView1.Columns.Count;
        this.dataGridView1.Rows.AddCopies(0, rows);
        for (int i = 0; i < this.Settings.Count; i++)
        {
          int row = i / cols;
          int col = i % cols;
          this.dataGridView1[col, row].Style.BackColor = this.Settings[i].BackColor;
          this.dataGridView1[col, row].Style.ForeColor = this.Settings[i].ForeColor;
          this.dataGridView1[col, row].Value = this.Settings[i].Value;
        }
      }
    }
