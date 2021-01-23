        if (VH.ID == 0 || VH.ID == null)
        {
            VH.State = State.Added;
            context.VoucherHeader.AddObject(VH);
        }
        else
        {
            VH.State = State.Modified;
            context.VoucherHeader.Attach(VH);
            context.ObjectStateManager.ChangeObjectState(VH, StateHelpers.GetEquivalentEntityState(VH.State));
        }
