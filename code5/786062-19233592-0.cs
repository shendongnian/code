    private IEnumerable<Control> ChildControls(Control parent) {
      List<Control> controls = new List<Control>();
      controls.Add(parent);
      foreach (Control ctrl in parent.Controls) {
        controls.AddRange(ChildControls(ctrl));
      }
      return controls;
    }
