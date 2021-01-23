        void SetCorrectOriginalValues(DbEntityEntry Modified)
        {
            var values = Modified.CurrentValues.Clone();
            Modified.Reload();
            Modified.CurrentValues.SetValues(values);
            Modified.State = EntityState.Modified;
        }
