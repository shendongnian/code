    private void SaveSettings()
    {
      this.Settings = new List<SavedSettings>();
      foreach (DataGridViewRow row in this.dataGridView1.Rows)
      {
        if (!row.IsNewRow)
        {
          foreach (DataGridViewCell cell in row.Cells)
          {
            SavedSettings setting = new SavedSettings();
            setting.BackColor = cell.Style.BackColor.ToArgb() == 0 ? Color.White : cell.Style.BackColor;
            setting.ForeColor = cell.Style.ForeColor.ToArgb() == 0 ? Color.Black :  cell.Style.ForeColor; ;
            setting.Value = cell.Value;
            this.Settings.Add(setting);
          }
        }
      }
      this.WriteXML();
    }
    private void WriteXML()
    {
      System.Xml.Serialization.XmlSerializer writer =
          new System.Xml.Serialization.XmlSerializer(typeof(List<SavedSettings>));
      System.IO.StreamWriter file = new System.IO.StreamWriter(@"SavedSettings.xml");
      writer.Serialize(file, this.Settings);
      file.Close();
    }
