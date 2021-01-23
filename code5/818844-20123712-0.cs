    var Output = (from x in MyDC.SomeTable
                  where  ....
                  select new SomeObjectModel()
                  {
                     SomeProp = x.SomeColumnField
    
                  }.SingleOrDefault(); //if only single item is expected or null
    
    return Output;
