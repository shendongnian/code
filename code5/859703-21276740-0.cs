    public void RegisterUser(User user)
    {
        // possibly you should also check that user is not registered yet
        _userRepository.Add(user);
        _emailService.SendGreeting(user);
    }
