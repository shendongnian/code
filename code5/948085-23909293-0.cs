    using System;
    using System.Data.Linq;
    using System.Data.Linq.Mapping;
    
    namespace LinqConsoleApp
    {
        public class SqlData : DataContext
        {
            public Table<TextbausteinTyp> TextbausteinTypen;
            public Table<Textbaustein> Textbausteins;
    
            public SqlData(string connectionString)
                : base(connectionString)
            {
            }
        }
    
        [Table(Name = "tqTextbausteinTyp")]
        public class TextbausteinTyp
        {
            [Column(IsPrimaryKey = true, DbType = "BigInt IDENTITY NOT NULL", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
            public int Id;
    
            [Column]
            public string Name;
        }
    
        [Table(Name = "tqTextbaustein")]
        public class Textbaustein
        {
            [Column(IsPrimaryKey = true, DbType = "BigInt IDENTITY NOT NULL", IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
            public int Id;
    
            private EntityRef<TextbausteinTyp> _TextbausteinTyp;
    
            [Association(Storage = "_TextbausteinTyp", ThisKey = "Id")]
            public TextbausteinTyp IdBausteintyp;
    
            [Column]
            public string Inhalt;
    
            [Column]
            public string Name;
        }
    
        internal class Program
        {
            private static void Main(string[] args)
            {
      
                var builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
                builder["Data Source"] = "<SERVERNAME>"
                builder["integrated Security"] = true;
                builder["Initial Catalog"] = "<DATABASE>";
    
                SqlData db = new SqlData(builder.ConnectionString);
    
                db.CreateDatabase();
                Console.ReadLine();
            }
        }
    }
