      public Control FindControl(Control control, string name) {
        foreach (Control childControl in control.Controls) {
          if (childControl.Id == name) return childControl;
          Control foundControl = FindControl(childControl, name);
          if (foundControl != null) return childControl;
        }
        return null;
      }
