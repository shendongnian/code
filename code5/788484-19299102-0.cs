        SqlCommand com = new SqlConnection(functions.ConnectionString).CreateCommand();
        com.CommandText = @"
	DECLARE @tbl AS dbo.typeClubMembersVersion
	BEGIN TRANSACTION
		UPDATE dbo.tClubMembers
		SET
			Title = @Title
		OUTPUT inserted.ID, deleted.[version] INTO @tbl (ID, [version])
		WHERE IdMember = @IdMember
		EXEC dbo.spCheckCMembersMods @tbl, @whoID
	COMMIT
    ";
        com.Parameters.Add("@Title", SqlDbType.NVarChar, 20).Value = this.Title;
        com.Parameters.Add("@IdMember", SqlDbType.BigInt).Value = this.Id;
        com.Parameters.Add("@whoID", SqlDbType.BigInt).Value = (object)whoID ?? DBNull.Value;
        com.Connection.Open();
        try
        {
            com.Connection.ChangeDatabase("MyOtherDatabase");
            com.ExecuteNonQuery();
        }
        catch (Exception exe)
        {
            throw exe;
        }
        finally
        {
            com.Connection.Close();
        }
