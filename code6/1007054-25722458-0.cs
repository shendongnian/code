    public void ReloadUsers()
    {
        profileCollection.Clear();
        var data = dbObj.GetDbData();
        if (data.Count != 0)
        {
            foreach (ProfileControl item in data)
            {
                profileCollection.Add(item);
            }
            this.profileList.DataContext = profileCollection;
        }
    }
