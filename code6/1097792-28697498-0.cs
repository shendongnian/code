	void IRepository<T>.Delete(params Guid[] ids)
	{
		if (ids == null || !ids.Any())
			return;
		var idParams = ids.Select((x, cnt)=> new { ParamName ="@ids"+ cnt, Param = "'"+x.ToString()+"'"});
		var sql = string.Format("UPDATE {0} SET [IsDeleted] = 1 WHERE [Id] IN ("+ String.Join(", ",idParams.Select(x =>  x.ParamName)) + ") ", "Table");
		var sqlParams = idParams.Select(x=> new SqlParameter(x.ParamName, x.Param)).ToArray(); 
		DataContext.Database.ExecuteSqlCommand(sql, sqlParams);
	}
