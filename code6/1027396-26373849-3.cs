    public IQueryable<WorkOrderDependencyViewModel> GetViewModel()
    {
        return repository.WorkOrderDependencies  // change to suit your query needs
                         .Select(AsViewModel);
                     
    }
