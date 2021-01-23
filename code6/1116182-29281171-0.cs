    [Serializable] 
    public struct CommissionListingItem 
    { 
      private System.Int32 _CommissionId; 
      private System.String _Description; private
      System.Double _Rate; 
      public System.Int32 CommissionId
      {
       get
         {
          return _CommissionId;
         }
       set
         {
           _CommissionId = value;
         }
      } 
     public System.String Description
     {
       get
         {
           return _Description;
         }
       set
         {
           _Description = value;
         }
       } 
      public System.Double Rate
      {
       get{return _Rate;}
       set { _Rate = value;}
      } 
    } 
