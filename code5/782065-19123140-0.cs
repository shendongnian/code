    public override void LoadDataToControls<T>(T Id)
    {
        if(id is Guid)
        {
            Guid guid = (Guid)(object)id;
        }
    }
