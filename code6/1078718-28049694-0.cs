    orders.AsEnumerable()
          .Select(x => new {
              // assuming o.OrderDate is in the format of yyyy-mm-dd
              OrderDate = DateTime.ParseExact("yyyy-mm-dd", x.OrderDate),
              SerialNumbers = o.SerialNumbers ?? "",
              SourceOrderNumber = o.SourceOrderID.ToString()
          }).Take(50);
