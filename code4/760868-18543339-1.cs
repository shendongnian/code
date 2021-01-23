    public void AddToCombo(Array array, ComboBox c)
    {
      foreach(var a in array)
      {
        c.Items.Add(a);
      }
    }
