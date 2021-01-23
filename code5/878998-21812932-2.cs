    OrmLiteConfig.InsertFilter = OrmLiteConfig.UpdateFilter = (dbCmd, row) =>
    {
        var auditRow = row as IAudit;
        if (auditRow != null)
        {
            if (auditRow.ModifiedBy == null)
                throw new ArgumentNullException("ModifiedBy");
        }
    };
    try
    {
        db.Insert(new AuditTableA());
    }
    catch (ArgumentNullException) {
       //throws ArgumentNullException
    }
    db.Insert(new AuditTableA { ModifiedBy = "Me!" }); //succeeds
