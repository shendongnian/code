    public string AddFile(Attachement file) {
        IExternalService eService = _externalServices.GetExternalService(id);
        IRepositoryWithAttachement repository = eService.Repository as IRepositoryWithAttachement;
        if (repository == null)
        {
            // report error in some appropriate way and return, or throw an
            // _informative_ exception, e.g.
            //     new NotSupportedException("repository does not support attachments")
        }
        repository.AddFile(file); 
    }
