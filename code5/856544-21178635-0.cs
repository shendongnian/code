    RadioButton1.Value;  
    if(RadioButton1)
    {
     string Sql_radio = "Insert Into tb1(name)Values ('Yes')";
    }
    else if(RadioButton2)
    {
     string Sql_radio = "Insert Into tb1(name)Values ('No')";
    }
