    class Program
    {
        static void Main(string[] args)
        {
            NewTask.Combine taskcombine = new NewTask.Combine();
            ProfileClient profilesws = new ProfileClient();
            var profileRecords = profilesws.GetAllProfiles();
            var tasks = new List<Task<ResultClass>>();
            var cts = new CancellationTokenSource();
            var token = cts.Token;            
            foreach (var profile in profileRecords.ProfileRecords)
            {
                var testProfile = new NewTask.Profile();
                testProfile.Id = profile.Id;
                testProfile.Name = profile.Name;
                tasks.Add(taskcombine.TestProfileAsync(testProfile, token))
            }
            int completedIndex = Task.WaitAny(tasks.ToArray());
            //This should stop any tasks before they even start.
            cts.Cancel();
            var result = tasks[completedIndex].Result;
            profilesws.Close();
            taskcombine.Close();
        }
    }
