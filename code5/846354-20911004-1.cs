        public FormularioVentasTO GetFormularioVentas(string idUsuario, string idFormulario)
        {
            FormularioVentasTO formVentas;
            string sqlQuery;
            SqlParameter []sqlParams;
            formVentas = null;
            try
            {
                sqlQuery = "sp_ConsultarSolicitud @idUsuario, @idSolicitud, codError";
                sqlParams = new SqlParameter[]
                {
                    new SqlParameter { ParameterName = "@idUsuario",  Value =idUsuario , Direction = System.Data.ParameterDirection.Input},
                    new SqlParameter { ParameterName = "@idSolicitud",  Value =idFormulario, Direction = System.Data.ParameterDirection.Input },
                    new SqlParameter { ParameterName = "@codError",  Value =-99, Direction = System.Data.ParameterDirection.Output },
                };
                
                using (PortalFinandinaPriv dbContext = new PortalFinandinaPriv())
                {
                    formVentas = dbContext.Database.SqlQuery<FormularioVentasTO>(sqlQuery, sqlParams).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                //handle, Log or throw exception 
            }
            return formVentas;
        }
