    var client = new RestClient(basicUrl);
    client.ExecuteAsync<User>(request, (response) =>
            {
                user = response.Data;
            });
    txtBox.Text = user.Name; //<---- its outside the Async event handler 
                            //so at this point user doesn't     
                            //have the info of the response
