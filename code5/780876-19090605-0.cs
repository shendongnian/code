    var textBoxes = new TextBox[] {textBox1, textBox2, textBox3, textBox4, textBox5};
    for (int i = 0; i < DataReader.FieldCount; i++)
    {
      if (DataReader.IsDBNull(i))
      {
        string CaseNull = "";
        ReaderResult.Add(CaseNull);
      }
      else
      {
        //put results in LIST<>
        ReaderResult.Add(DataReader.GetString(i));
      }
      // put data i onto textbox i
      textBoxes[i].Text = DataReader.GetString(i);
    }
