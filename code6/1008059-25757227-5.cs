    void OnObjectMaterialized( object sender, ObjectMaterializedEventArgs e )
    {
        var entity = e.Entity as IMaterializable;
        if ( entity != null )
        {
            entity.OnMaterialized();
        }
    }
