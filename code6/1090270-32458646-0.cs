    // Action to return the session value. This method should be inside a controller class.
    public object GetSession(string sessionName)
    {
        return Session[sessionName];
    }
    // JavaScript code to retrieve session "TEST":
    $http.get('action/url/' + "TEST").
        success(function (sessionValue) {
            alert('Session "TEST" has the following value: ' + sessionValue);
        }
    );
