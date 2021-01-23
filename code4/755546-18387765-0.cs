    private void Update(...)
    {
        //... do some stuff ... 
       await _repository.Save(listing);
    }
    protected override async Task Save(...)
    {
       
            ... do some stuff ...
            _logger.Debug("All Done!!!");
    }
