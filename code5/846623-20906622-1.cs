     var query = from x in dbContext.TableX
                 join y in dbContext.TableY on x.our_id equals y.our_id 
                 join z in dbContext.TableZ on y.our_id equals z.our_id 
                 join a in dbContext.TableA on z.other_id equals a.other_id 
                 where !string.IsNullOrEmpty(x.status)
                 select new MyType
                 {
                    MyTypeField1 = a.Column1
                 ,  MyTypeField2 = z.Column3
                 ,  // ...and so on
                 }; // No need to convert to IQueryable - this should produce the right type
    return result;
