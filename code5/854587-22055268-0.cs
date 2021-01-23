	using System.Linq.Expressions;
	using SQLite;
	using System.Collections.Generic;
    
	public static class DeleteExtensions
	{
		public static int Delete<T>(this TableQuery<T> tableQuery, Expression<Func<T, bool>> predExpr)
		{
			BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
			Type type = tableQuery.GetType();
			MethodInfo method = type.GetMethod("CompileExpr", flags);
			if (predExpr.NodeType == ExpressionType.Lambda) {
				var lambda = (LambdaExpression)predExpr;
				var pred = lambda.Body;
				var args = new List<object> ();
				var w = method.Invoke(tableQuery, new object[] {pred, args});
				var compileResultType = w.GetType();
				var prop = compileResultType.GetProperty("CommandText");
				string commandText = prop.GetValue(w, null).ToString();
				var cmdText = "delete from \"" + tableQuery.Table.TableName + "\"";
				cmdText += " where " + commandText;
				var command = tableQuery.Connection.CreateCommand (cmdText, args.ToArray ());
				int result = command.ExecuteNonQuery();
				return result;
			} else {
				throw new NotSupportedException ("Must be a predicate");
			}
		}
	}
