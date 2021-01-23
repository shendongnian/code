    public static SqlDataAdapter CreateSQLAdapter(SqlConnection vx130)
            {
                SqlDataAdapter da = new SqlDataAdapter();
    
                // Create the SelectCommand.
                SqlCommand command = new SqlCommand("Select DatabaseName, DWPhysicalSchemaName, DWPhysicalTableName, " + 
                    "DWFieldName ,DataDomain, DWFieldDataType, DWFieldLength, DWFieldScale, SourceAttributeSID, "+
                    "ResolvedValue, PointedToField, MapComments, PrimaryKeyEntitySID, SpecialHandlingFlag, "+
                    "DWFieldTechnicalDescription, BuildStatus from meta.attributemap", vx130);
    
                da.SelectCommand = command;
    
                // Create the InsertCommand.
                command = new SqlCommand(
                 "Insert Into [Meta].[AttributeMap] " +
                    "(DatabaseName, DWPhysicalSchemaName, DWPhysicalTableName, " +
                    "DWFieldName ,DataDomain, DWFieldDataType, DWFieldLength, DWFieldScale, SourceAttributeSID, " +
                    "ResolvedValue, PointedToField, MapComments, PrimaryKeyEntitySID, SpecialHandlingFlag, " +
                    "DWFieldTechnicalDescription, BuildStatus ) " +
    
    
                 "Values (@DatabaseName, @DWPhysicalSchemaName, @DWPhysicalTableName, " +
                    "@DWFieldName ,@DataDomain, @DWFieldDataType, @DWFieldLength, @DWFieldScale, @SourceAttributeSID, " +
                    "@ResolvedValue, @PointedToField, @MapComments, @PrimaryKeyEntitySID, @SpecialHandlingFlag, " +
                    "@DWFieldTechnicalDescription, @BuildStatus)" , vx130);
    
                // Add the parameters for the InsertCommand.
                command.Parameters.Add(new SqlParameter("@DatabaseName", SqlDbType.VarChar));
                command.Parameters["@DatabaseName"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DatabaseName"].SourceColumn = "DatabaseName";
    
                command.Parameters.Add(new SqlParameter("@DWPhysicalSchemaName", SqlDbType.VarChar));
                command.Parameters["@DWPhysicalSchemaName"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWPhysicalSchemaName"].SourceColumn = "DWPhysicalSchemaName";
    
                command.Parameters.Add(new SqlParameter("@DWPhysicalTableName", SqlDbType.VarChar));
                command.Parameters["@DWPhysicalTableName"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWPhysicalTableName"].SourceColumn = "DWPhysicalTableName";
    
                command.Parameters.Add(new SqlParameter("@DWFieldName", SqlDbType.VarChar));
                command.Parameters["@DWFieldName"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWFieldName"].SourceColumn = "DWFieldName";
    
                command.Parameters.Add(new SqlParameter("@DataDomain", SqlDbType.VarChar));
                command.Parameters["@DataDomain"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DataDomain"].SourceColumn = "DataDomain";
    
                command.Parameters.Add(new SqlParameter("@DWFieldDataType", SqlDbType.VarChar));
                command.Parameters["@DWFieldDataType"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWFieldDataType"].SourceColumn = "DWFieldDataType";
    
                command.Parameters.Add(new SqlParameter("@DWFieldLength", SqlDbType.VarChar));
                command.Parameters["@DWFieldLength"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWFieldLength"].SourceColumn = "DWFieldLength";
    
                command.Parameters.Add(new SqlParameter("@DWFieldScale", SqlDbType.Int));
                command.Parameters["@DWFieldScale"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWFieldScale"].SourceColumn = "DWFieldScale";
    
                command.Parameters.Add(new SqlParameter("@SourceAttributeSID", SqlDbType.Int));
                command.Parameters["@SourceAttributeSID"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@SourceAttributeSID"].SourceColumn = "SourceAttributeSID";
    
                command.Parameters.Add(new SqlParameter("@ResolvedValue", SqlDbType.VarChar));
                command.Parameters["@ResolvedValue"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@ResolvedValue"].SourceColumn = "ResolvedValue";
    
                command.Parameters.Add(new SqlParameter("@PointedToField", SqlDbType.VarChar));
                command.Parameters["@PointedToField"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@PointedToField"].SourceColumn = "PointedToField";
    
                command.Parameters.Add(new SqlParameter("@MapComments", SqlDbType.VarChar));
                command.Parameters["@MapComments"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@MapComments"].SourceColumn = "MapComments";
    
                command.Parameters.Add(new SqlParameter("@PrimaryKeyEntitySID", SqlDbType.Int));
                command.Parameters["@PrimaryKeyEntitySID"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@PrimaryKeyEntitySID"].SourceColumn = "PrimaryKeyEntitySID";
    
                command.Parameters.Add(new SqlParameter("@SpecialHandlingFlag", SqlDbType.VarChar));
                command.Parameters["@SpecialHandlingFlag"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@SpecialHandlingFlag"].SourceColumn = "SpecialHandlingFlag";
    
                command.Parameters.Add(new SqlParameter("@DWFieldTechnicalDescription", SqlDbType.VarChar));
                command.Parameters["@DWFieldTechnicalDescription"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWFieldTechnicalDescription"].SourceColumn = "DWFieldTechnicalDescription";
    
                command.Parameters.Add(new SqlParameter("@BuildStatus", SqlDbType.VarChar));
                command.Parameters["@BuildStatus"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@BuildStatus"].SourceColumn = "BuildStatus";
    
                da.InsertCommand = command;
    
                // Create the UpdateCommand.
                command = new SqlCommand(
                    "UPDATE [Meta].[AttributeMap] "+
                    "SET DatabaseName = @DatabaseName, DWPhysicalSchemaName = @DWPhysicalSchemaName, " +
                    "DWPhysicalTableName=@DWPhysicalTableName, DWFieldName=@DWFieldName, DataDomain=@DataDomain," +
                    "DWFieldDataType=@DWFieldDataType, DWFieldLength=@DWFieldLength, DWFieldScale=@DWFieldScale," +
                    "SourceAttributeSID=@SourceAttributeSID, ResolvedValue=@ResolvedValue, @PointedToField=@PointedToField," +
                    "MapComments=@MapComments, PrimaryKeyEntitySID=@PrimaryKeyEntitySID, SpecialHandlingFlag=@SpecialHandlingFlag," +
                    "DWFieldTechnicalDescription=@DWFieldTechnicalDescription, BuildStatus=@BuildStatus  " +
    
                    "WHERE DWPhysicalSchemaName = @DWPhysicalSchemaName and DWPhysicalTableName= @DWPhysicalTableName and DWFieldName=@DWFieldName", vx130);
    
                command.Parameters.Add(new SqlParameter("@DatabaseName", SqlDbType.VarChar));
                command.Parameters["@DatabaseName"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DatabaseName"].SourceColumn = "DatabaseName";
    
                command.Parameters.Add(new SqlParameter("@DWPhysicalSchemaName", SqlDbType.VarChar));
                command.Parameters["@DWPhysicalSchemaName"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWPhysicalSchemaName"].SourceColumn = "DWPhysicalSchemaName";
    
                command.Parameters.Add(new SqlParameter("@DWPhysicalTableName", SqlDbType.VarChar));
                command.Parameters["@DWPhysicalTableName"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWPhysicalTableName"].SourceColumn = "DWPhysicalTableName";
    
                command.Parameters.Add(new SqlParameter("@DWFieldName", SqlDbType.VarChar));
                command.Parameters["@DWFieldName"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWFieldName"].SourceColumn = "DWFieldName";
    
                command.Parameters.Add(new SqlParameter("@DataDomain", SqlDbType.VarChar));
                command.Parameters["@DataDomain"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DataDomain"].SourceColumn = "DataDomain";
    
                command.Parameters.Add(new SqlParameter("@DWFieldDataType", SqlDbType.VarChar));
                command.Parameters["@DWFieldDataType"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWFieldDataType"].SourceColumn = "DWFieldDataType";
    
                command.Parameters.Add(new SqlParameter("@DWFieldLength", SqlDbType.VarChar));
                command.Parameters["@DWFieldLength"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWFieldLength"].SourceColumn = "DWFieldLength";
    
                command.Parameters.Add(new SqlParameter("@DWFieldScale", SqlDbType.Int));
                command.Parameters["@DWFieldScale"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWFieldScale"].SourceColumn = "DWFieldScale";
    
                command.Parameters.Add(new SqlParameter("@SourceAttributeSID", SqlDbType.Int));
                command.Parameters["@SourceAttributeSID"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@SourceAttributeSID"].SourceColumn = "SourceAttributeSID";
    
                command.Parameters.Add(new SqlParameter("@ResolvedValue", SqlDbType.VarChar));
                command.Parameters["@ResolvedValue"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@ResolvedValue"].SourceColumn = "ResolvedValue";
    
                command.Parameters.Add(new SqlParameter("@PointedToField", SqlDbType.VarChar));
                command.Parameters["@PointedToField"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@PointedToField"].SourceColumn = "PointedToField";
    
                command.Parameters.Add(new SqlParameter("@MapComments", SqlDbType.VarChar));
                command.Parameters["@MapComments"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@MapComments"].SourceColumn = "MapComments";
    
                command.Parameters.Add(new SqlParameter("@PrimaryKeyEntitySID", SqlDbType.Int));
                command.Parameters["@PrimaryKeyEntitySID"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@PrimaryKeyEntitySID"].SourceColumn = "PrimaryKeyEntitySID";
    
                command.Parameters.Add(new SqlParameter("@SpecialHandlingFlag", SqlDbType.VarChar));
                command.Parameters["@SpecialHandlingFlag"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@SpecialHandlingFlag"].SourceColumn = "SpecialHandlingFlag";
    
                command.Parameters.Add(new SqlParameter("@DWFieldTechnicalDescription", SqlDbType.VarChar));
                command.Parameters["@DWFieldTechnicalDescription"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWFieldTechnicalDescription"].SourceColumn = "DWFieldTechnicalDescription";
    
                command.Parameters.Add(new SqlParameter("@BuildStatus", SqlDbType.VarChar));
                command.Parameters["@BuildStatus"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@BuildStatus"].SourceColumn = "BuildStatus";
    
                da.UpdateCommand = command;
    
                // Create the DeleteCommand.
                command = new SqlCommand(
                     "delete from vx130.Meta.AttributeMap " +
                        " where DWPhysicalSchemaName =   @DWPhysicalSchemaName  AND " +
                           " DWPhysicalTableName =  @DWPhysicalTableName  AND  DWFieldName = @DWFieldName", vx130);
    
                // Add the parameters for the DeleteCommand.
                command.Parameters.Add(new SqlParameter("@DWPhysicalSchemaName", SqlDbType.VarChar));
                command.Parameters["@DWPhysicalSchemaName"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWPhysicalSchemaName"].SourceColumn = "DWPhysicalSchemaName";
    
                command.Parameters.Add(new SqlParameter("@DWPhysicalTableName", SqlDbType.VarChar));
                command.Parameters["@DWPhysicalTableName"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWPhysicalTableName"].SourceColumn = "DWPhysicalTableName";
    
                command.Parameters.Add(new SqlParameter("@DWFieldName", SqlDbType.VarChar));
                command.Parameters["@DWFieldName"].SourceVersion = DataRowVersion.Current;
                command.Parameters["@DWFieldName"].SourceColumn = "DWFieldName";
    
                da.DeleteCommand = command;
    
                return da;
            }
        }
    
    }
