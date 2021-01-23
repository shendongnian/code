    public OrgBO(IOrgBase entity){
            PopulateFrom(entity);
    }
    public void PopulateFrom(IOrgBase entity){
            this.ID = entity.GetID();
            this.Type =  entity.GetType();
            this.Name = entity.GetName();
            if (entity.GetParent() !=null)
            {
                this.Parent = new OrgBO(entity.GetParent());
            }
        }
