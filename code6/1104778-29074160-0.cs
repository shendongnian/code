           var _customers = new DataServiceCollection<Table>(_context);
            // Specify an OData query that returns all customers.
            var query = (from cust in _context.Customer
                        select cust)
                        as DataServiceQuery<Table>;
            var ar = query.BeginExecute(null, null);
            ar.AsyncWaitHandle.WaitOne();
            response = query.EndExecute(ar) as QueryOperationResponse<Table>;
            _customers.Load(response);
            var continuation = response.GetContinuation();            
            while (continuation != null)
            {
                var ar2 = _context.BeginExecute<Table>(continuation, null, null);
                ar2.AsyncWaitHandle.WaitOne();
                var response2 = _context.EndExecute<Table>(ar2) as QueryOperationResponse<Table>;
                _customers.Load(response2);
                continuation = response2.GetContinuation();
            }
