     [HttpPost]
            public HttpResponseMessage Insert(LookupViewModel model)
            {
                try
                {
                    EducationLookup result = AutoMapperGenericsHelper<LookupViewModel, EducationLookup>.ConvertToDBEntity(model);
                    this.Uow.EducationLookups.Add(result);
                    Uow.Commit(User.Id);
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                catch (DbEntityValidationException e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, CustomExceptionHandler.HandleDbEntityValidationException(e));
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.HResult.HandleCustomeErrorMessage(ex.Message));
                }
    
            }
