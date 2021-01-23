    public ExaminationRepository(DBEntities context, IPrincipal user)
    {
        this.context = context;
        this.user    = user;
    }
