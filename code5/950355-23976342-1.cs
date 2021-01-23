                EntityKey ekProducto = new EntityKey("DbCursoEntity.Productos", "Id", producto.Id);
    
                using (dbCurso = new DbCursoEntity())
                {
                    producto.EntityKey = ekProducto; //Añado la key a la entidad.
    
                    dbCurso.Attach(producto); //Enlanzo la entidad mediante Attach.
                    dbCurso.DeleteObject(producto); //Elimino la entidad.
    
                    if (dbCurso.SaveChanges() > 0)
                        return true;
                    else
                        return false;
    
                }
