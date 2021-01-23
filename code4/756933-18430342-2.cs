    class Program
    {
        static void Main(string[] args)
        {
            NewTask.Combine taskcombine = new NewTask.Combine();
            ProfileClient profilesws = new ProfileClient();
            var profileRecords = profilesws.GetAllProfiles();
            var tasks = new List<Task<ResultClass>>();
            foreach (var profile in profileRecords.ProfileRecords)
            {
                var testProfile = new NewTask.Profile();
                testProfile.Id = profile.Id;
                testProfile.Name = profile.Name;
                tasks.Add(taskcombine.TestProfileAsync(testProfile))
            }
            int completedIndex = Task.WaitAny(tasks.ToArray());
            var result = tasks[completedIndex].Result;
            profilesws.Close();
            taskcombine.Close();
        }
    }
