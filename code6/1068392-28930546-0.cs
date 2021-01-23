    public void RemoveUserFromGroup(Group group, User user)
        {
                var internalGroup = _activeDirectoryClient.Context.CreateQuery<GraphClient.Internal.Group>("groups/" + group.ObjectId).ToList().First();
                var internalUser = _activeDirectoryClient.Context.CreateQuery<GraphClient.Internal.User>("users/" + user.ObjectId).ToList().First();
                _activeDirectoryClient.Context.DeleteLink(internalGroup, "members", internalUser);
                _activeDirectoryClient.Context.SaveChanges();           
        }
