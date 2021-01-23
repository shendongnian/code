    PlusService plusService = new PlusService(
                    new Google.Apis.Services.BaseClientService.Initializer()
                    {
                        ApiKey = API_KEY
                    });
    Person me = plusService.People.Get(@"+GusClass").Execute();
