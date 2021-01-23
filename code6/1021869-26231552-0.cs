    class Program
    {
        private static readonly Action<string> DebugWriteLine = s => System.Diagnostics.Debug.WriteLine(s);
        private static readonly Action<string> WriteLine = s => { System.Console.WriteLine(s); DebugWriteLine(s); };
        static void Main(string[] args)
        {
            Statics.Entities.Database.Log = WriteLine;
            WhereClauseOnSimpleProperty();
            WhereClauseOnNavigationProperty();
            WhereClauseOnICollection();
            WhereClauseOnIQueryable();
            WhereClauseOnIQueryableWithIQueryable();
            System.Console.ReadKey();
        }
        static void WhereClauseOnSimpleProperty()
        {
            WriteLine("Get objects with a where clause (simple property).");
            WriteLine("    Calling: var users = entities.Users.Where(u => u.FirstName == \"Julie\");");
            var users = Statics.Entities.Users.Where(u => u.FirstName == "Julie");
            WriteLine("    Calling: users.ToList();");
            var usersList = users.ToList();
            // SQL got built and called here (NOTE: SQL call is not made until the data needs to be "realized"):
            /* SELECT 
                [Extent1].[Id] AS [Id], 
                [Extent1].[Uin] AS [Uin], 
                [Extent1].[ClientId] AS [ClientId], 
                [Extent1].[FirstName] AS [FirstName], 
                [Extent1].[LastName] AS [LastName]
            FROM [dbo].[Users] AS [Extent1]
            WHERE 'Julie' = [Extent1].[FirstName]
            */
            WriteLine("    There are " + usersList.Count + " users.");
        }
        static void WhereClauseOnNavigationProperty()
        {
            WriteLine("Get objects with a where clause (1-to-many navigation property).");
            WriteLine("    Calling: var users = Entities.Users.Where(u => u.FirstName == \"Julie\" && u.Votes.Any());");
            var users = Statics.Entities.Users.Where(u => u.FirstName == "Julie" && u.Votes.Any());
            WriteLine("    Calling: users.ToList();");
            var usersList = users.ToList();
            // SQL got built and called here (NOTE: using the ICollection navigation property on the lambda parameter "u" builds just one SQL statement):
            /* SELECT 
                [Extent1].[Id] AS [Id], 
                [Extent1].[Uin] AS [Uin], 
                [Extent1].[ClientId] AS [ClientId], 
                [Extent1].[FirstName] AS [FirstName], 
                [Extent1].[LastName] AS [LastName]
            FROM [dbo].[Users] AS [Extent1]
            WHERE ('Julie' = [Extent1].[FirstName]) AND ( EXISTS (SELECT 
                1 AS [C1]
                FROM [dbo].[Votes] AS [Extent2]
                WHERE [Extent1].[Id] = [Extent2].[UserId]
            ))
            */
            WriteLine("    There are " + usersList.Count + " users.");
        }
        static void WhereClauseOnICollection()
        {
            WriteLine("Get objects with a where clause (simple property) from an ICollection.");
            WriteLine("    Calling: var users = Entities.Users.First(u => u.FirstName == \"Julie\" && u.Votes.Any());");
            var user = Statics.Entities.Users.First(u => u.FirstName == "Julie" && u.Votes.Any());
            // SQL got built and called here (NOTE: data is realized immediately because we are allocating a single object):
            /* SELECT TOP (1) 
                [Extent1].[Id] AS [Id], 
                [Extent1].[Uin] AS [Uin], 
                [Extent1].[ClientId] AS [ClientId], 
                [Extent1].[FirstName] AS [FirstName], 
                [Extent1].[LastName] AS [LastName]
            FROM [dbo].[Users] AS [Extent1]
            WHERE ('Julie' = [Extent1].[FirstName]) AND ( EXISTS (SELECT 
                1 AS [C1]
                FROM [dbo].[Votes] AS [Extent2]
            WHERE [Extent1].[Id] = [Extent2].[UserId]
            ))
            */
            WriteLine("    Calling: var votes = user.Votes.AsQueryable().Where(v => v.VoteValue > 0);");
            var votes = user.Votes.AsQueryable().Where(v => v.VoteValue > 0);
            // SQL got built and called here (NOTE: there "where" clause is executed in app memory/time [it's not in the SQL call]):
            /* SELECT 
                [Extent1].[Id] AS [Id], 
                [Extent1].[UserId] AS [UserId], 
                [Extent1].[VoteValue] AS [VoteValue]
            FROM [dbo].[Votes] AS [Extent1]
            WHERE [Extent1].[UserId] = @EntityKeyValue1
            */
            WriteLine("    Calling: votes.ToList();");
            var votesList = votes.ToList();
            WriteLine("    There are " + votesList.Count + " votes.");
        }
        static void WhereClauseOnIQueryable()
        {
            WriteLine("Get objects with a where clause (1-to-many navigation property) from an IQueryable.");
            WriteLine("    Calling: var users = Entities.Users.First(u => u.FirstName == \"Julie\" && u.Votes.Any());");
            var user = Statics.Entities.Users.First(u => u.FirstName == "Julie" && u.Votes.Any());
            // SQL got built and called here:
            /* SELECT TOP (1) 
                [Extent1].[Id] AS [Id], 
                [Extent1].[Uin] AS [Uin], 
                [Extent1].[ClientId] AS [ClientId], 
                [Extent1].[FirstName] AS [FirstName], 
                [Extent1].[LastName] AS [LastName]
            FROM [dbo].[Users] AS [Extent1]
            WHERE ('Julie' = [Extent1].[FirstName]) AND ( EXISTS (SELECT 
                1 AS [C1]
                FROM [dbo].[Votes] AS [Extent2]
            WHERE [Extent1].[Id] = [Extent2].[UserId]
            ))
            */
            WriteLine("    Calling: var votes = user.QueryableVotes.Where(v => user.Votes.AsQueryable().Contains(v));");
            var votes = user.QueryableVotes.Where(v => user.Votes.AsQueryable().Contains(v));
            // SQL got built and called here (NOTE: this is just the "user.Votes.AsQueryable().Contains(v)" part of the query):
            /* SELECT 
                [Extent1].[Id] AS [Id], 
                [Extent1].[UserId] AS [UserId], 
                [Extent1].[VoteValue] AS [VoteValue]
            FROM [dbo].[Votes] AS [Extent1]
            WHERE [Extent1].[UserId] = @EntityKeyValue1
            */
            WriteLine("    Calling: votes.ToList();");
            var votesList = votes.ToList();
            // NOTE: EF6 dies here because it had already computed "user.Votes.Contains(v)" (see above), and that can't go into the query.
            WriteLine("    There are " + votesList.Count + " votes.");
        }
        static void WhereClauseOnIQueryableWithIQueryable()
        {
            WriteLine("Get objects with a where clause (1-to-many navigation property as an IQueryable) from an IQueryable.");
            WriteLine("    Calling: var users = Entities.Users.First(u => u.FirstName == \"Julie\" && u.Votes.Any());");
            var user = Statics.Entities.Users.First(u => u.FirstName == "Julie" && u.Votes.Any());
            // SQL got built and called here:
            /* SELECT TOP (1) 
                [Extent1].[Id] AS [Id], 
                [Extent1].[Uin] AS [Uin], 
                [Extent1].[ClientId] AS [ClientId], 
                [Extent1].[FirstName] AS [FirstName], 
                [Extent1].[LastName] AS [LastName]
            FROM [dbo].[Users] AS [Extent1]
            WHERE ('Julie' = [Extent1].[FirstName]) AND ( EXISTS (SELECT 
                1 AS [C1]
                FROM [dbo].[Votes] AS [Extent2]
            WHERE [Extent1].[Id] = [Extent2].[UserId]
            ))
            */
            WriteLine("    Calling: var votes = user.QueryableVotes.Where(v => user.QueryableVotes.Contains(v));");
            var votes = user.QueryableVotes.Where(v => user.QueryableVotes.Contains(v)); // Yes, I know this is reduntant...just making sure the SQL looks right.
            WriteLine("    Calling: votes.ToList();");
            var votesList = votes.ToList();
            // SQL got built and called here (NOTE: making all expressions true IQueryables will build the "correct" [one call to rule them all] SQL expression):
            /* SELECT 
                [Extent1].[Id] AS [Id], 
                [Extent1].[UserId] AS [UserId], 
                [Extent1].[VoteValue] AS [VoteValue]
            FROM [dbo].[Votes] AS [Extent1]
            WHERE ([Extent1].[UserId] = @p__linq__0) AND ( EXISTS (SELECT 
                1 AS [C1]
                FROM [dbo].[Votes] AS [Extent2]
                WHERE ([Extent2].[UserId] = @p__linq__1) AND ([Extent2].[Id] = [Extent1].[Id])
            ))
            */
            WriteLine("    There are " + votesList.Count + " votes.");
        }
        // SPECIAL NOTE: The clauses should follow these guidelines:
        /*
            * 1. If the condition operates on the lambda parameter, then use the ICollection navigation property to achieve one statement.
            *      For example: var user = Statics.Entities.Users.First(u => u.FirstName == "Julie" && u.Votes.Any());
            * 2. If the condition operates on a "non-navigation" property of the lambda parameter, then use the IQueryable expression to acheive one statement.
            *      For example: var votes = user.QueryableVotes.Where(v => user.QueryableVotes.Contains(v));
        */
    }
    public partial class User
    {
        public IQueryable<Vote> QueryableVotes
        {
            get
            {
                return Statics.Entities.Votes.Where(v => v.UserId == this.Id);
            }
        }
    }
