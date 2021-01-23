    // define as static 
    static Quaternion Identity = new Quaternion(0,0,0,1);
  
    Quaternion Q1 = Quaternion.Identity;
    //or 
    if ( Q1.Length == Unit ) // not considering floating point error
