    public T FindByEager(int id)
        {
            T entity = FindBy(id);
            NHibernateUtil.Initialize(entity);
            return entity;
        }
