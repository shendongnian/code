    if(!_client.LoggedIn)
    {
        _client.LoginAsync("basic_info,publish_actions,read_stream,user_photos");
    }
    else
    {
        //just use the _client variable
    }
