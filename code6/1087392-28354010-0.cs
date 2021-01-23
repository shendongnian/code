    while(count < 18)
                {                    
    
                    //Find string key 
    		        var uc1 = tabPage3.Controls.Find("AbsenceUC", true).Where(x=> YOUR WHERE CLAUSE HERE).Single();
    
                    //Cast your controls to TextBoxes
                    TextBox TxtEmployeeID = uc1.Controls.Find("txtEmpId", true).Single() as TextBox;
                    TextBox TxtAbsenteeCode = uc1.Controls.Find("TextBox2", true).Single() as TextBox;
                    String txttext = TxtEmployeeID.Text;
                }
