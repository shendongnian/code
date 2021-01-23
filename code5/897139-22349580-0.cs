    private DataTable _dt;
    public DataTable dt
    {
        get
        {
            return _dt;
        }
        set
        {
            _dt= value;
        }
    }
    Void Load()
    {
      dt.Columns.Add("Text");
  
      for (int i = 0; i < doc.Sentences.Count; i++)
      {
        string temp = doc.Sentences[i + 1].Text;
        if (temp != string.Empty)
        { 
          data.Add(temp);
          dt.Rows.Add(new object[] { data });
        } 
      }
    }
