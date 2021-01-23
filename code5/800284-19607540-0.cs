    System.DateTime? _MyDateTime;
    public System.DateTime? MyDateTime {get; set;}
            if (DateTime.TryParse(myReader["myColumn"], out MyDateTime ))
            {
                //do stuffs if value is parsed successfully
            }
            else
            {
 
            }
