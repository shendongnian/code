    orders.Take(50)
          .AsEnumerable()
          .Select(x => new {
              // assuming o.OrderDate is in the format of yyyy-mm-dd
              OrderDate = DateTime.ParseExact(x.OrderDate, "yyyy-mm-dd" CultureInfo.InvariantCulture),
              SerialNumbers = o.SerialNumbers ?? "",
              SourceOrderNumber = o.SourceOrderID.ToString()
          });
