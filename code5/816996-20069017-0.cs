      //if you have muliple condition then use StringBuilder class 
       //for making column list
            string strColumns=string.Empty;
            if(CoditionForL1)
            {
                strColumns =strColumns+ "[L1] ,";
            }
            if (ConditionForL2)
            {
                strColumns = strColumns + "[L2],";
            }
 
       string qry = "select "+(strColumns= strColumns.TrimEnd(','))+" from [Sheet1$]"; 
