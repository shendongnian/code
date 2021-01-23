    string str = "2009/11/17 12.31.35";
    
    string year = str.Substring(0, 4);    //2009
    string month = str.Substring(5, 2);   //11
    string date = str.Substring(8, 2);    //17
    string Hours = str.Substring(11, 2);  //12
    string minutes = str.Substring(14, 2);//31
    string seconds = str.Substring(17, 2);//35
