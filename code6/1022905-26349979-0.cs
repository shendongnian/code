    private IEnumerable<Document> GetDocumentsOfUser(Guid userId)
        {
            using (var db = new DocumentRepositoryEntities())
            {
                var ownedRepositories = db.Repositories
                              .Where(r => r.Owner.UserId == userId);
                var userInOtherTeams =
                     db.Users.Where(u => u.UserId == userId)
                            .SelectMany(u => u.Teams)
                            .SelectMany(t => t.Users);
                var repositoriesOwnedByTeamMembers =
                    userInOtherTeams.Where(u => u.Repositories.Any())
                                    .SelectMany(u => u.Repositories)
                                    .Where(r => !r.Private);
                var allRepositories = ownedRepositories.Concat(
                                      repositoriesOwnedByTeamMembers);
                return allRepositories.SelectMany(r => r.Documents)
                                      .Distinct()
                                      .ToArray(); //query will be composed here!
            }
        }
