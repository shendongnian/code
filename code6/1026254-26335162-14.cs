    public UserManager(User user, IStateManager stateManager)
    {
        _user = Requires.IsNotNull(user, nameof(user));
        _stateManager = Requires.IsNotNull(statemanager, nameof(statemanager));
    }
