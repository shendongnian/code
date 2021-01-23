     public void Update(T entidad)
        {
            try
            {
                if (entidad == null)
                    throw new ArgumentNullException("entidad");
    
                _contexto.Entry(entidad).State = System.Data.EntityState.Modified;
                this._contexto.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw dbEx;
            }
        }
