    public UserManager(User user, IStateManager stateManager)
    {
        _user = Requires.IsNotNull(user, "user");
        _stateManager = Requires.IsNotNull(statemanager, "statemanager");
    }
