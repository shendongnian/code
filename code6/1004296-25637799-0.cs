    if (e.Row.RowType == DataControlRowType.Header)
        {    //creating column 
            List<Module> listModule = getModules();
                foreach (Module m in listModule)
                {
                    TemplateField tfield = new TemplateField();
                    tfield.HeaderTemplate = new TickColumn(m.ModuleName);        
					tfield.Controls.Add(cbActive);
					CheckBox cbActive = new CheckBox();
					cbActive.ID = m.ModuleID.ToString();
                    gvUsers.Columns.Add(tfield);
                }
        }
