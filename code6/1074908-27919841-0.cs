    public static bool DetectSqlInjection(string Text)
	{
		string CleanText = Text.ToUpper().Replace("/**/", " ").Replace("+", " ").Replace("  ", " ");
    
		string[] InjectionPatterns = { 
										 "VARCHAR", 
										 "EXEC", 
										 "DECLARE", 
										 "SELECT *", 
										 "SELECT PASSWORD", 
										 "SELECT USERNAME", 
										 "$_GET",
										 "NULL OR",
										 "UNION ALL SELECT",
										 "WAITFOR DELAY",
										 "SELECT pg_sleep",
										 "SHOW TABLES FROM"
   										 };
    
		foreach (string Pattern in InjectionPatterns)
		{
			if (CleanText.Contains(Pattern))
				return true;
		}
    
		return false;
	}
