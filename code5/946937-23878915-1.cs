    // is it an IEnumerable?
    var item = callback(request);
    var enumerable = item as IEnumerable;
    if(enumerable != null) 
    {
      var enumerator = enumerable.GetEnumerator();
      if(!enumerator.MoveNext())
      {
         // handle an empty collection here
      }
      else
      {
         do 
         {
            if(enumerator.Current == null)
              // handle the null value here
         } while(enumerator.MoveNext());
      }
    }
