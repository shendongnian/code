    List<MessageRequest> requests = new List<MessageRequest>();
            requests.Add(new MessageRequest(Guid.NewGuid().ToString(), Operation.GetBudgets));
            requests.Add(new MessageRequest(Guid.NewGuid().ToString(), Operation.GetCatalogItems));
            List<MessageResponse> responses;
            using (ServiceManager sm = new ServiceManager())
            {
                responses = sm.GetData(requests);
            }
            if (responses != null)
            {
                
                foreach (var response in responses)
                {
                    switch (response.Request.Operation)
                    {
                        case Operation.GetBudgets:
                            List<Budget> budgets = response.Data<List<Budget>>();
                            break;
                        case Operation.GetCatalogItems:
                            List<Item> items = response.Data<List<Item>>();
                            break;
                    }
                }
            }
