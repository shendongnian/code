        // <summary>
        // When attaching we need to check that the entity is not already attached to a different context
        // before we wipe away that context.
        // </summary>
        private void VerifyContextForAddOrAttach(IEntityWrapper wrappedEntity)
        {
            if (wrappedEntity.Context != null
                && wrappedEntity.Context != this
                && !wrappedEntity.Context.ObjectStateManager.IsDisposed
                && wrappedEntity.MergeOption != MergeOption.NoTracking)
            {
                throw new InvalidOperationException(Strings.Entity_EntityCantHaveMultipleChangeTrackers);
            }
        }
