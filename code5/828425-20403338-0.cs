    var paymentDetails = dataSet.Tables[i].AsEnumerable()
                             .Select(r => new PaymentAccDetails
                             {
                                 PaymentRef = r[n],
                                 StartDate = r[o],
                                 ...
                             }
                             .ToList();
