        IQueryable<Request> IRepository.BestRequests {
			get { return Requests.Where(r => r.Type == Type.BestRequest); }
		}
		IQueryable<Request> IRepository.AwesomeRequests {
			get { return Requests.Where(r => r.Type == Type.AwesomeRequest); }
		}
