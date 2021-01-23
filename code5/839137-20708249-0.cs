        Expression<Func<ProductoAtributo, bool>> productoAtributoWhere = pa => true;
        
        
        			string CantidadDormitorios = "";
        
        
        			if (! String.IsNullOrEmpty(CantidadDormitorios))
        			{
        				productoAtributoWhere = pa => (pa.Valor == CantidadDormitorios && pa.AtributoId == 7) || (pa.Valor == CantidadDormitorios && pa.AtributoId == 6);
        			}
        
        var producto = from p in db.Producto
            						   join pa in db.ProductoAtributo on p.ProductoId equals pa.ProductoId into pa_join
            						   from pa in pa_join.DefaultIfEmpty().AsQueryable().Where( productoAtributoWhere )
            						   join tpa in db.TipoProductoAtributo
            								 on new { pa.AtributoId, p.TipoProductoId }
            							 equals new { tpa.AtributoId, tpa.TipoProductoId } into tpa_join
            						   from tpa in tpa_join.DefaultIfEmpty()
            						   join tp in db.TipoProducto on p.TipoProductoId equals tp.TipoProductoId into tp_join
            						   from tp in tp_join.DefaultIfEmpty()
    select new
    						   { p };
            var producto1 = producto.ToList();
