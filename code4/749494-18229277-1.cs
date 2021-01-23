     NorthwindEntities db = new NorthwindEntities();
        Variables vrbl = Variables.CreateVariables(a[0]);// usually have atleast one value 
     if(!String.IsNullOrEmpty(a[1]))
        AdId = a[1]; 
     if(!String.IsNullOrEmpty(a[2]))
        Variable1= a[2]; // assign the corresponding values from List of strings 
     if(!String.IsNullOrEmpty(a[3]))
        Variable2= a[3];
     if(!String.IsNullOrEmpty(a[4])) 
        Variable3= a[4];
     if(!String.IsNullOrEmpty(a[5])) 
        Variable4= a[5];
     if(!String.IsNullOrEmpty(a[6]))
        Variable5= a[6];
     if(!String.IsNullOrEmpty(a[7])) 
        Variable6= a[7];
     if(!String.IsNullOrEmpty(a[8])) 
        Variable7= a[8];
     if(!String.IsNullOrEmpty(a[9])) 
        Variable8= a[9];
        
        db.Variables.AddObject(vrbl); 
        db.SaveChanges();
 
