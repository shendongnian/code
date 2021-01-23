    List<Control> removeList = new List<Control>();
    foreach (Control c in splitMain.Panel2.Controls)
    {
       if (c.GetType() == typeof(CommandLink))
       {
          CommandLink cl = (CommandLink)c;
          removeList.Add( c1);
       }
    }
    foreach(Control c in removeList )
    {
       splitMain.Panel2.Controls.Remove(cl);
    }
