     // Create List 	  
     List<Permission> permissions = new List<Permission>(new Permission[]{             
       new Permission { Id = "ID1" , Name = "Send SMS"},           
       new Permission { Id = "ID2", Name = "Send Email"}            });
       // Iterate through list to set CreatedAt to correct value 
       foreach (Permission p in permissions){
          // Get the record from the db if it exists              
          var t = context.PermissionSet.Where(s => s.Id == p.Id).FirstOrDefault();
          if (t != null){
             p.CreatedAt = t.CreatedAt; //SET CreatedAt to correct Value if the record already exists                
          }
          context.PermissionSet.AddOrUpdate(a => a.Id, p); // NOW I CAN UPDATE WITH NO PROBLEM
       } 
       
