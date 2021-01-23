    catch (DbUpdateException ex)
                        {
                            var sqlex = ex.InnerException.InnerException as SqlException;
                            if (sqlex != null)
                            {
                                switch (sqlex.Number)
                                {
                                    case 547: throw new ExNoExisteUsuario("No existe usuario destino."); //FK exception
                                    case 2627:
                                    case 2601:
                                        throw new ExYaExisteConexion("Ya existe la conexion."); //primary key exception
                                    default: throw sqlex; //otra excepcion que no controlo.
                                              
                                }
                            }
                            throw ex;
                        }
