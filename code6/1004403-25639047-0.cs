    private void loopThroughSheet(Sheet _sheet)
    {
       foreach (e.Control ctrl in _sheet.Controls)
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
