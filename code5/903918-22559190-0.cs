        partial class Program {
          static partial void initGlobalLogic( ref SystemLogic globalLogic ) {
            globalLogic = new YourGlobalLogicClass();
          }
          static partial void ewlMain( string[] args ) {
            DataAccessState.Current.PrimaryDatabaseConnection.ExecuteWithConnectionOpen( () => {
              // Your code goes here.
              // Skip the ExecuteWithConnectionOpen call if you don't need the database.
            }
          }
        }
