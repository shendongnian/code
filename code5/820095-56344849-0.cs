    var context = new DbContext("name = JobManagerConnection");
    var entry = context.Entry(new Models.JobManager.Job());
    var errInner = new System.Data.Entity.Validation.DbValidationError("Test Property", "Test Message");
    var lstErrInner = new List<System.Data.Entity.Validation.DbValidationError> { errInner };
    var errOuter = new System.Data.Entity.Validation.DbEntityValidationResult (entry, lstErrInner);
    var lstErrOuter = new List<System.Data.Entity.Validation.DbEntityValidationResult> { errOuter };
    throw new System.Data.Entity.Validation.DbEntityValidationException("Test Data Exception", lstErrOuter);
