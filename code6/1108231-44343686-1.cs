        public virtual ObjectResult<Nullable<string>> CalculatedValueSproc(Nullable<int> Id)
        {
            var IdParameter = Id.HasValue ?
            new ObjectParameter("Id", Id) :
            new ObjectParameter("Id ", typeof(int));
        
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable< string >>("CalculatedValueSproc", Id);
    }
