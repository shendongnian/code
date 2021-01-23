    using System;
    using System.Data.SqlClient;
    using System.Linq;
    namespace Data.Db
    {
		public partial class OracleBlogModel 
		{
			public OracleBlogModel(string connectionString)
				: base(connectionString){}
		}
	}
