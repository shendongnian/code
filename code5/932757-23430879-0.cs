      private readonly IRepository _repository;
       public MyViewModel() : this(new EfRepository())
       {
       }
       public MyViewModel(IRepository repository)
       {
          _repository = repository;
       }
