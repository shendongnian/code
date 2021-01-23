            var estimatedCloseDate = DateTime.Parse("2014-10-07");
            Guid createdId = Guid.Empty;
            Entity matchingEntity = null;
            try
            {
                // Create a test opp
                var opp = new Entity("opportunity");
                opp["name"] = "Testing Date Filter";
                opp["customerid"] = new EntityReference("account", Guid.Parse("b9b0ed35-2a11-4fb6-a56f-5b8c04a3c1d1")); // A valid customer
                opp["estimatedclosedate"] = estimatedCloseDate;
                createdId = _service.Create(opp);
                Console.WriteLine("Created Id: {0}", createdId);
                // Create the filter expression
                QueryExpression queryCRM = new QueryExpression
                {
                    EntityName = "opportunity",
                    ColumnSet = new ColumnSet(true)
                };
                queryCRM.Criteria.AddCondition("estimatedclosedate", ConditionOperator.On, estimatedCloseDate);
                // Run the search and check for a match vs the record just created
                var results = _service.RetrieveMultiple(queryCRM);
                foreach (var result in results.Entities)
                {
                    if (result.Id == createdId)
                    {
                        matchingEntity = result;
                    }
                }
                // Survey says... 
                Console.WriteLine(matchingEntity == null
                                    ? "Matching entity not found!"
                                    : "Matching entity found!");
            }
            finally
            {
                // Delete the created opp
                if (createdId != Guid.Empty)
                {
                    _service.Delete("opportunity", createdId);
                }
            }
