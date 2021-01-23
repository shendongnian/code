    var user = userRepository.Get(1);
    var accessChecker = authorizationRepository.GetForUser(id);
    if (!accessChecker.MaySendEmail(user))
        throw new SecurityException("You may not send emails");
    var emailSender = new EmailSenderService();
    emailSender.Send(user, txtDestination.Text, txtMessage.Text);
    repos.Save(user);
