    public async Task<IEnumerable<Member>> GetAllMembersAsync()
    {
       var members = Repository.GetAll<Member>();
       return await Task.Run(() => members.ToListAsync());
    }
    private async void LoadMembers()
    {
       try
       {
           var members = await MemberService.GetAllMembersAsync().ConfigureAwait(true);
           Members = new ObservableCollection<Member>(members);
       }
       catch (EntityException)
       {
        // connection lost?
       }
    }
