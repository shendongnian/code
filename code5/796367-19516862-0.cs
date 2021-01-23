      var last = decimal.MaxValue;
      var decreasing = true;
      foreach(var value in dataTable.AsEnumerable()
                                .Select(r => r.Field<string>(1))
                                .Where(s => !string.IsNullOrWhiteSpace(s))
                                .Select(Decimal.Parse))
      {
          if (last < value)
          {
              decreasing = false;
              break;
          }
          last = value;
      }
           
