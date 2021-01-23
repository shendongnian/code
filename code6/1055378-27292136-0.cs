    cboDepartment.Items.Add("--Select Department--");
     while (oReader.Read())
      {                   
        string _Combobox = oReader["Name"].ToString();
        cboDepartment.Items.Add(_Combobox);
      }
      cboDepartment.selectedIndex=0; 
          
      
    
