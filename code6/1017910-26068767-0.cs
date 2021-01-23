    using System;
    using System.Data;
    using System.Data.SQLite;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Dapper;
    
    namespace MyConsoleApplication
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var test = new TestSQLite();
                test.GoForIt();
            }
        }
    
        public class Entity
        {
            public int Id { get; set; }
            public string Content { get; set; }
        }
    
        public class TestSQLite
        {
            private const string ConnectionString = "Data Source=sqlitetest.sqlite";
            private static readonly object DbLock = new object();
    
            public void GoForIt()
            {
                CreateTable();
    
                var random = new Random();
    
                for (int i = 0; i < 100; i++)
                {
                    if ( i % 2 != 0)
                    {
                        Task.Factory.StartNew(() => Thread.Sleep(random.Next(0, 200))).ContinueWith(other => 
                            LocalDbScope(action =>
                                {
                                    var entity = new Entity {Content = "hoax"};
                                    entity.Id = action.Query<int>(
                                        @"insert into entity (content) values (@Content); select last_insert_rowid()",
                                        entity).First();
                                    var ids = action.Query<int>(@"select id from entity").ToList();
                                    Console.WriteLine("Inserted id:{0}, all ids:[{1}]", entity.Id, string.Join(",", ids));
                                }));
                    }
                    else
                    {
                        Task.Factory.StartNew(() => Thread.Sleep(random.Next(200, 500))).ContinueWith(other => 
                            LocalDbScope(action =>
                                {
                                    action.Execute(@"delete from entity");
                                    Console.WriteLine("Deleted all entities");
                                }));
                    }
                }
    
                Console.ReadLine();
            }
    
            public static void LocalDbScope(Action<IDbConnection> action)
            {
                lock (DbLock)
                {
                    using (var connection = new SQLiteConnection(ConnectionString))
                        action(connection);
                }
            }
    
            private static void CreateTable()
            {
                using (IDbConnection c = new SQLiteConnection(ConnectionString))
                {
                    c.Execute(@"drop table if exists entity");
                    c.Execute(@"create table entity (id integer primary key autoincrement, content varchar(100))");
                }
            }
        }
    }
