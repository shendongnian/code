    private void dumpControls(Control ctl, string parents)
    {
      if (parents == "") parents = ctl.Name; else parents += "." + ctl.Name;
      if (ctl.Name != "" && ctl.Text != "") Console.WriteLine(parents  + "=" + ctl.Text);
      foreach (Control ct in ctl.Controls) dumpControls(ct, parents);
    }
