    .OrderBy(X =>
                 {
                    switch (OrderByColumn)
                    {
                       case "":
                          return X.a.CreatedOn;
                       case "BookCategoryName":
                          return new DateTime(1900,1,1);
                       case "BookCategoryDescription":
                          return new DateTime(1900,1,1);
                    }
                    return X.a.CreatedOn;
                 })
    .ThenBy(X =>
                 {
                    switch (OrderByColumn)
                    {
                       case "":
                          return "";
                       case "BookCategoryName":
                          return X.a.BookCategoryName;
                       case "BookCategoryDescription":
                          return X.a.BookCategoryDescription;
                    }
                    return "";
                 });
