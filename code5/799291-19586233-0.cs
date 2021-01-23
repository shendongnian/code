     public void Delete(int id)
        {
            var entity = this.GetById(id);
            if (entity!=null)
            {
                this.Delete(entity);
            }
        }
