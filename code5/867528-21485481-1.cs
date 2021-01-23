     public GridView Cr_GridView(string[] ColNames,string[] ColLable, string[] ColFormat)
            {
                GridView GV = new GridView();
                int x = ColNames.GetUpperBound(0);
    
                for (int i = 0; i < x; i++)
                {
                    BoundField GvField = new BoundField();
    
                    GvField.DataField = ColNames[i];
                    GvField.HeaderText = ColLable[i];
                    GvField.DataFormatString = ColFormat[i];// for example "{0:dd/MM/yyyy}" for a date field
                    
                    GV.Columns.Add(GvField);
                }
                return GV;
            } 
