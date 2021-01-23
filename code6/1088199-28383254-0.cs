    public async Task<IEnumerable<Member>> GetAllMembersAsync()
    {
        return await Repository.GetAll<Member>().ToListAsync().ConfigureAwait(false);
    }
    
    private async void LoadMembers()
    {
        try
        {
            var members = await MemberService.GetAllMembersAsync();
            Members = new ObservableCollection<Member>(members);
        }
        catch (EntityException)
        {
            // connection lost?
        }
    }
