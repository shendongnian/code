        [HttpGet]
        public GridProperties<ClientListModel> GetClients(int page)
        {
            const int rowsToDisplay = 10;
            try
            {
                IEnumerable<ClientListModel> clientList = null;
    
                using (var context = new AngularModelConnection())
                {
                    clientList = context.Clients.Select(i => new ClientListModel()
                    {
                        ClientId = i.Id,
                        FirstName = i.FirstName,
                        LastName = i.LastName,
                        StartDate = i.StartDate,
                        Status = (i.DischargeDate == null || i.DischargeDate > DateTime.Now) ? "Active" : "Discharged"
                        });
    
                        int total = clientList.Count(); //Get count of total records
                        int totalPages = Convert.ToInt16(Math.Ceiling((decimal) total/rowsToDisplay)); //Get total page of records
    
                        return new GridProperties<ClientListModel>
                        {
                            Rows = clientList.Skip((page - 1)*rows).Take(rows).ToList(),
                            Records = total,
                            Total = totalPages,
                            Page = page
                        };
                    }
                }
                catch (Exception exc)
                {
                    ExceptionLogger.LogException(exc);
                    return new GridProperties<ClientListModel>
                    {
                        Rows = null,
                        Records = 0,
                        Total = 0,
                        Page = page
                    };
                }
            }
