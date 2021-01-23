    dbr.SelectString = "select name, gender,  address, contactno from userInfo where id = = '" + userId + "' --"; 
    DataTable DataTable_Values= dbr.GetTable(); 
    lbl_name =  DataTable_Values.Rows[0].Field<string>("name");
    lbl_gender =  DataTable_Values.Rows[0].Field<int>("gender");
    lbl_contact =  DataTable_Values.Rows[0].Field<int>("contact")
