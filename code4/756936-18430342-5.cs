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
                //If the token is canceled before the task gets to start itself it should never start and go stright to the "Canceled" state.
                tasks.Add(Task.Run(() => 
                           {
                               token.ThrowIfCancellationRequested(); //In case the task started but we did get a result before the last 
                               return taskcombine.TestProfile(testProfile); //Assumes "taskcombine.TestProfile(...)" is thread safe.
                           }, token));
            }
            var result = Task.WhenAny(tasks).Result;
            //This should stop any tasks that have not spun up yet from spinning up
            cts.Cancel();
            profilesws.Close();
            taskcombine.Close();
        }
    }
