    public class OrgBO<TEntity, TParent> : IEntity
        where TEntity : IEntity // Generic type constraints
        where TParent : IEntity // Generic type constraints
    {
        private TEntity _entity;
        
        public OrgBO(TEntity entity)
        {
            _entity = entity;
            if (entity.Type == OrgTypes.Level1) {
                this.ParentBO = null;
            } else {
                this.ParentBO = new OrgBO<TParent>(entity.Parent);
            }
        }
        
        public int ID { get { return _entity.ID; } set{ _entity.ID = value; } }
        public OrgTypes Type { get { return _entity.Type; } }
        public string Name { get { return _entity.Name; } set{ _entity.Name = value; } }
        
        // Implement explicitly in order to hide it if not accesses through interface.
        IEntity IEntity.Parent {
            get { return _entity.Parent; }
            set{ _entity.Parent = value; }
        }
        
        public OrgBO<TParent> ParentBO { get; private set; }
    }
