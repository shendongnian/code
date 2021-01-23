    public static void HandleError(Session session, int error, string message)
    {
        Record record = new Record(2);
        session["EXCEPTIONTEXT"] = message;
        session.Message(InstallMessage.Error, record);
    }
