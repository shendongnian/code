    List<Control> removeList = new List<Control>();
    foreach (Control c in splitMain.Panel2.Controls)
    {
       if (c.GetType() == typeof(CommandLink))
       {
          removeList.Add( c);
       }
    }
    foreach(Control c in removeList )
    {
       splitMain.Panel2.Controls.Remove(c);
    }
