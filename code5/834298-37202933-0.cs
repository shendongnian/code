    Microsoft.Office.Interop.Excel.Application xlApp = 
    	new Microsoft.Office.Interop.Excel.Application();
    Microsoft.Office.Interop.Excel.Workbook xlWorkBook = 
    	default(Microsoft.Office.Interop.Excel.Workbook);
    xlWorkBook = xlApp.Workbooks.Open("C:\\Book3.csv");
    object DocProps = xlWorkBook.BuiltinDocumentProperties;
    
    string strIndex = "Last Save Time";
    string strValue;
    object oDocSaveProp = typeDocBuiltInProps.InvokeMember("Item", 
    						   BindingFlags.Default | 
                               BindingFlags.GetProperty, 
    						   null,oDocBuiltInProps, 
    						   new object[] {strIndex} );
    Type typeDocSaveProp = oDocSaveProp.GetType();
    strValue = typeDocSaveProp.InvokeMember("Value", 
    						   BindingFlags.Default |
    						   BindingFlags.GetProperty,
    						   null,oDocSaveProp,
    						   new object[] {} ).ToString();
    MessageBox.Show(strValue, "Last Save Time");
