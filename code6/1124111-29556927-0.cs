     public List<Visitor> SearchRecord (string word)
    {
       var viewByName = db.GetView<Visitor>("ByName","ByName");
       var visitorQuery = viewByName.CreateQuery();
       visitorQuery.StartKey = new List<object> {word};
       visitorQuery.Limit = 100;
       var visitors = visitorQuery.Run();
       var visitorList = new List<Visitor> ();
    
       foreach (var visitor in visitors) {
         visitorList.Add(visitor.Document); 
         System.Console.WriteLine(visitor.Key);
       }
       return visitorList;
    }
