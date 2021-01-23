    public System.DateTime current = System.DateTime.Now;
    public System.DateTime Licensedate {get; set}
    if( Licensedate.Subtract(current).TotalDays >1 ){
        //... do somethink
    }
