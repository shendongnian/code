        object fieldValue = fieldInfo.GetValue( obj );
        if ( fieldValue is IEnumerable )
          {
          foreach ( var item in (IEnumerable)fieldValue )
            {
            //do your stuff
            Console.WriteLine(item.GetType());
            Console.WriteLine(item);
            }
          }
