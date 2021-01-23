    //Get the Internet connection profile
    string connectionProfileInfo = string.Empty;
    try {
        ConnectionProfile InternetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
        if (InternetConnectionProfile == null) {
            NotifyUser("Not connected to Internet\n");
        }
        else {
            connectionProfileInfo = GetConnectionProfile(InternetConnectionProfile);
            NotifyUser("Internet connection profile = " +connectionProfileInfo);
        }
    }
    catch (Exception ex) {
        NotifyUser("Unexpected exception occurred: " + ex.ToString());
    }
