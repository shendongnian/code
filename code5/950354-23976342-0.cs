        EntityKey ekProducto = new EntityKey("DbCursoEntity.Productos", "Id", producto.Id);
        using (dbCurso = new DbCursoEntity())
        {
            producto.EntityKey = ekProducto; //Añado la key a la entidad.
            dbCurso.Productos.Attach(producto); //Enlanzo la entidad al ObjectSet mediante Attach.
            dbCurso.Productos.DeleteObject(producto); //Elimino la entidad.
            if (dbCurso.SaveChanges() > 0)
                return true;
            else
                return false;
        }
