    namespace YourNameSpace
    {
	    [ExpressionPrefix("EncryptedExpressionStrings")]
	    public class EncryptedConnectionStringExpressionBuilder : ExpressionBuilder
	    {
            private static string DecryptConnectionString(string cipherText)
		    {
			    return Encryption.Decrypt(cipherText);
		    }
		    public static ConnectionStringSettings GetConnectionStringSettings(string connectionStringName)
		    {			
			    return ConfigurationManager.ConnectionStrings[connectionStringName];
		    }
            public static string GetConnectionString(string connectionStringName)
		    {
			    string decryptedConnectionString = null;
			    System.Web.Caching.Cache connectionStringCache = new System.Web.Caching.Cache();
			    if (connectionStringCache["connectionString"] == null)
			    {
				    ConnectionStringSettings settings = GetConnectionStringSettings(connectionStringName);
				    decryptedConnectionString = DecryptConnectionString(settings.ConnectionString);
				    connectionStringCache.Insert("connectionString", decryptedConnectionString);
			    }
			   else
			   {
				   decryptedConnectionString = (string)connectionStringCache["connectionString"];
			    }
			    return decryptedConnectionString;
		    }
		    public static string GetConnectionStringProviderName(string connectionStringName)
		    {
			    ConnectionStringSettings settings = GetConnectionStringSettings(connectionStringName);			
			    return settings.ProviderName;
		    }
            public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
		    {
			    Pair pair = DirectCast<Pair>(parsedData);
			    string text = pair.First.ToString();
			    if (Convert.ToBoolean(pair.Second))
			    {
				    return new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(base.GetType()), "GetConnectionString", new CodeExpression[] { new CodePrimitiveExpression() { Value = text } });
			    }
			    else
			    {
				    return new CodeMethodInvokeExpression(new CodeTypeReferenceExpression(base.GetType()), "GetConnectionStringProviderName", new CodeExpression[] { new CodePrimitiveExpression() { Value = text } });
			}
            static T DirectCast<T>(object o) where T : class
		    {
			    T value = o as T;
			    if (value == null && o != null)
			    {
				    throw new InvalidCastException();
			    }
			    return value;
		    }
        }
