    var result = dc.UserProductDetails
                   .Where(eml => eml.IsActive && !eml.IsDeleted)
                   .Search(eml => eml.aspnet_User.LoweredUserName) // Search LoweredUsername
                   .IsEqual(strUserName)                           // when equals strUsername
                   .Search(eml => eml.UserName,                    // Search UserName
                           eml => eml.ProductURL,                  // OR ProductUrl
                           eml => eml.Nickname)                    // OR Nickname
                   .Containing(strSearch)                          // When contains strSearch
                   .Select(eml => new UserProductDetailResult      // Build result...
                                  {
                                       _userProductDetail = eml
                                  });
