                try
                {
                    await transportWeb.DeliverAsync(mensaje);
                }
                catch (InvalidApiRequestException ex)
                {
                    var detalle = new StringBuilder();
    
                    detalle.Append("ResponseStatusCode: " + ex.ResponseStatusCode + ".   ");
                    for (int i = 0; i < ex.Errors.Count(); i++)
                    {
                        detalle.Append(" -- Error #" + i.ToString() + " : " + ex.Errors[i]);
                    }
    
                    throw new ApplicationException(detalle.ToString(), ex);
                }
