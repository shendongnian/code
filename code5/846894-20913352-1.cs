    void Context_ObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
    {
        var contextAwareEntity = e.Entity as IMyEntityStatusChange;
        if (contextAwareEntity != null)
        {
            contextAwareEntity.Context = this;
        }
    }
