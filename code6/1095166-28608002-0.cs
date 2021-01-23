    var obj = new account
    {
      id = 100,
      // etc.
      approve_stages = new List<approve_stage> 
      {
        new approve_stage 
        {
          policies = new List<ApprovePolicy>
          {
            new ApprovePolicy
            {
              type = "Foo",
              approver_id = 100
            }
          }
        }
      }  
    };
