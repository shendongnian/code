                try
                {
                   //your Odata query and response code 
                }
                catch (DataServiceClientException dsce)
                {
                    logger.WarnFormat("Client Exception, Status Code - {0}", dsce.StatusCode.ToString());
                }
                catch (DataServiceRequestException dsre)
                {
                    logger.WarnFormat("Request Exception - {0}", dsre.Message);
                }
                catch (DataServiceQueryException dsqe)
                {
                    logger.WarnFormat("Query Exception, Status code - {0}", dsqe.Response.StatusCode.ToString());
                }
