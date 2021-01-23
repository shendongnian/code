    public UserManager(User user, IStateManager stateManager)
    {
        Requires.IsNotNull(user, "user");
        Requires.IsNotNull(statemanager, "statemanager");
        _user = user;
        _stateManager = statemanager;
    }
