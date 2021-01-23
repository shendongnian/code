    public List<Ticket> All(List<int> Roles)
    {
        List<Ticket> tickets = _repository.All().Where(x => x.Workflow.Permissions.Any(y => Roles.Contains(y.RoleID))).ToList<Ticket>();
    
        return tickets;
    }
