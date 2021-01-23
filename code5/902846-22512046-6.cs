        private readonly IRepository<TModel, Guid> _repository;
        protected AutoMapper<TModel> ToModel;
        protected AutoMapper<TViewModel> ToViewModel;
        protected ServiceBase(IRepository<TModel, Guid> repository)
        {
            _repository = repository;
            ToModel = new AutoMapper<TModel>();
            ToViewModel = new AutoMapper<TViewModel>();
        }
        public virtual TViewModel Save(TViewModel viewModel)
        {
            // todo: go over this with Keith and make sure we're handling this properly with regards to syncing and Exception Handling.
            // look at UserService for the hacked alternative
            if (viewModel.Id != Guid.Empty)
            {
                // The ModelObject Id is not empty, we're either updating an existing ModelObject
                // or we're inserting a new ModelObject via sync
                var model = _repository.GetById(viewModel.Id);
                if (model != null)
                {
                    // Looks like we're updating a ModelObject because it's already in the database.
                    _repository.Update(ToModel.BuildFrom(viewModel));
                    return ToViewModel.BuildFrom(_repository.GetById(viewModel.Id));
                }
            }
            // The ModelObject is being created, either via a Sync (Guid Exists), or via an Insert (Guid doesn't Exist)
            var id = _repository.Create(ToModel.BuildFrom(viewModel));
            return ToViewModel.BuildFrom(_repository.GetById(id));
        }
        public virtual TViewModel GetById(Guid id)
        {
            var model = _repository.GetById(id);
            return ToViewModel.BuildFrom(model);
        }
        public virtual IList<TViewModel> Find()
        {
            return ToViewModel.BuildListFrom(_repository.Find());
        }
        public virtual void Delete(TViewModel viewModel)
        {
            var model = ToModel.BuildFrom(viewModel);
            _repository.Delete(model);
        }
    }
