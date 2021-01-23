    private void Function(IEnumerable<Control> controls)
            {
                foreach (e.Control ctrl in controls)
                {
                    switch (ctrl.TYPE)
                    {
                        case "StaticText":
                            CompareControls.StaticText lbl = new CompareControls.StaticText();
                            page1.tabPage1.Controls.Add(lbl);
                            break;
                        case "CheckBox":
    
                            break;
                    }
                }
            }
