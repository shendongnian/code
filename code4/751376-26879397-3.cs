    Class Member  
    {  
      public int MemberId{get;set;}  
      public string FirstName{get;set;}  
      public string LastName{get;set;}  
      public string MemberType{get;set;}  
    }  
    
    Class MemberViewModel  
    {       
      public int MemberId{get;set;}   
      public string FirstName{get;set;}  
      public string LastName{get;set;}  
    }  
    [HttpPost]  
    Public ActionResult Create(MemberViewModel memberviewmodel)  
    {  
     Save(memberviewmodel);  
    }
