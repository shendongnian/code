    for(int i = 0; i<items.count();i++)
        {
            var ob = items[i];
            for(int j = i+1;j<items.Count();j++)
                {
                   if(ob.Rectangle.Intersects(items[j].rectangle))
                       {
                         //DO Somthing
                       }
                  }
        }
