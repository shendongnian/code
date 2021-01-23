            Task t1 = Task.Run(() => GetBusinessProcesses(-1));
            Task t2 = Task.Run(() => GetActivityRoles(-1));
            Task t3 = Task.Run(() => Tools = toolService.GetTools().ToSelectListItem(x => x.Name, x => x.ToolId.ToString(), true).ToList());
            Task t4 = Task.Run(() => BusinessAreas = businessAreaService.GetBusinessAreas().ToSelectListItem(x => x.Name, x => x.BusinessAreaId.ToString(), true).ToList())
                .ContinueWith(t =>
            {
                // Populate the functional area dropdown data
                if (BusinessAreas != null && BusinessAreas.Any())
                {
                    int businessAreaId = System.Convert.ToInt32(BusinessAreas[0].Value);
                    GetFunctionalAreas(businessAreaId);
                }
            });
            try
            {
                Task.WaitAll(t1, t2, t3, t4);
            }
            catch (Exception ex)
            {
                throw new Exception("Error populating dropdowns.  See inner exception.", ex);
            }
