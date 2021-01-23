        public class RepsonseHolder()
        {
             public string Valor {get;set;}
             public string Codigo {get;set;}
        }
        
        var myList = new List<RepsonseHolder>();
        foreach (var item in response)
        {
             var newHolder = new RepsonseHolder();
             newHolder.Valor = item.Column(5);  // Or however you can get at your Ids
             newHolder.Cordigo = item.Column(7);
             myList.Add(newHolder);
        }
