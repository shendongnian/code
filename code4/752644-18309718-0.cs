      private static void ExecuteInClientContext(int Id, Action<SqlDatabaseClient> callback) {
        if (callback == null) {
          throw new ArgumentNullException("callback");
        }
        using(MySqlConnection Connection = new MySqlConnection(GenerateConnectionString())) {
          Connection.Open();
          callback.Invoke(new SqlDatabaseClient(Id, Connection));
        }
      }
      static void Foo() {
        ExecuteInClientContext(1, (context) => {
          // whatever
        });
      }
