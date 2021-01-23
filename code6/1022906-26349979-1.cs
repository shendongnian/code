    private IEnumerable<Document> GetDocumentsOfUser(Guid userId)
        {
            using (var db = new DocumentRepositoryEntities())
            {
                // Get owned repositories by the user
                var ownedRepositories = db.Repositories
                              .Where(r => r.Owner.UserId == userId);
                // Get all users of teams the user belongs to
                var userInOtherTeams =
                     db.Users.Where(u => u.UserId == userId)
                            .SelectMany(u => u.Teams)
                            .SelectMany(t => t.Users);
                // Get the public repositories owned by the teammembers
                var repositoriesOwnedByTeamMembers =
                    userInOtherTeams.Where(u => u.Repositories.Any())
                                    .SelectMany(u => u.Repositories)
                                    .Where(r => !r.Private);
                // Combine (union) the 2 lists of repositories
                var allRepositories = ownedRepositories.Concat(
                                      repositoriesOwnedByTeamMembers);
                // Get all the documents from the selected repositories
                return allRepositories.SelectMany(r => r.Documents)
                                      .Distinct()
                                      .ToArray(); //query will be composed here!
            }
        }
