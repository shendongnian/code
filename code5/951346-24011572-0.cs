    //in generated partial
    public DateTime DateCreatedDB { get; set; }
    //in second file that contains your partial of that class 
    public DateTime DateCreated
    {
         get { // return converted DateCreatedDB }
         set { // set DateCreatedDB to unconveted value }
    }
