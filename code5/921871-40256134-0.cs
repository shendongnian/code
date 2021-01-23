    public override void Dispose()
        {
            if(uow != null)
            {
                uow.Dispose();
            }
            base.Dispose();
        }
