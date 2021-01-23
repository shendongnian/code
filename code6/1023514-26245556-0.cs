    using (var context = new DbContext())
    {
            while (!jobDone)
            {
                // Execute job and get data
                var returnData = doOneSetJob();
                // Process job results
                foreach (var one in returnData)
                {
                    try
                    {
                        context.TargetTable.Add(one);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        // Log the error
                    }
                }
            }
    }
The using statement will guarantee that your context is cleaned up properly, even if an error occurs while you are looping through the results.
