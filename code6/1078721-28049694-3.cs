    orders.Take(50)
          .AsEnumerable()
          .Select(x => new {
              OrderDate = x.OrderDate.Date,
              SerialNumbers = o.SerialNumbers ?? "",
              SourceOrderNumber = o.SourceOrderID.ToString()
          });
