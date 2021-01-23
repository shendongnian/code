    public HttpResponseMessage Get()
    {
        using (DAL.Repositories.Repository<Machine> machineRepo = new DAL.Repositories.Repository<Machine>())
        {
            var machineOperators = machineRepo.FindAll(x => x.Active).Include(x=>x.Operators).Where(x => x.Operators.All(o =>o.Active)).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, machineOperators);
        }
    }
