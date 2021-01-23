    static void Main(string[] args)
        {
            Data data =  new Data();
            var membersName = data.GetType().GetMembers().Select(m=>m.Name); 
            
    
        }
