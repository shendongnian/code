    public IOwnerProperties CreateOrModifyOwner(Guid id)
    {
    
        //get an owner ...
    
        //Mapper.Map retuns a object of type OwnerDataContract
        return Mapper.Map<OwnerDataContract>(theOwner);
    }
