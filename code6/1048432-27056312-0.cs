            var serializer = new JavaScriptSerializer();
            string json =
                serializer.Serialize(
                    new
                        {
                            main = new
                                       {
                                           reg_FirstName = "Bob", 
                                           reg_LastName = "The Guy"
                                       },
                            others = new[]
                                         {
                                             new { reg_FirstName = "Bob", reg_LastName = "The Guy" }, 
                                             new { reg_FirstName = "Bob", reg_LastName = "The Guy" }
                                         }
                        });
