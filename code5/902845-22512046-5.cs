    public abstract class RepositoryBase<TModel> where TModel : ModelBase, new()
    {
        protected RepositoryBase(UserModel loggedOnUser,
                                 IDbProvider dbProvider)
        {
            DbProvider = dbProvider;
            LoggedOnUser = loggedOnUser;
        }
        public virtual Guid Create(TModel model)
        {
            // Create the record
            DbProvider.Create(model);
            return model.Id;
        }
       public virtual TModel GetById(Guid id)
        {
            var model = DbProvider.Query<TModel>(m => m.Id == id).FirstOrDefault();
            if (model == null)
            {
                throw new NotFoundException(string.Format(NotFoundMessage, id));
            }
            return model;
        }
        public virtual IList<TModel> Find()
        {
            return DbProvider.Query<TModel>(m => m.IsDeleted == false).ToList();
        }
        public virtual void Update(TModel model)
        {
            // Set the update/create info
            SetCreateInfo(model);
            // Update the record
            try
            {
                DbProvider.Update(model);
            }
            catch (Exception ex)
            {
                ThrowKnownExceptions(ex);
            }
        }
        public virtual void Delete(TModel model)
        {
            // Do NOT SetUpdateInfo(model); it's being done in the Update method.
            model.IsDeleted = true;
            Update(model);
        }
        public virtual void Delete(Guid id)
        {
            var model = GetById(id);
            Delete(model);
        }
    }
