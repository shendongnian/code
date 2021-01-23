    static void Main(string[] args)
            {
    
                Data data =  new Data();
                //you can use this for your case 
                var fields = data.GetType().GetFields().Select(f => f.Name);
               
                foreach (var f in fields)
                {
                    Console.WriteLine(f);
    
                }
               Console.WriteLine("===");
                //but if you want a more generic one try this 
                var members = data.GetType().GetMembers().Select(m=>m.Name);
                foreach (var member in members)
                {
                    Console.WriteLine(member);
    
                }
    
                
                
    
            }
