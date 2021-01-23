        /// <summary>The app activity type for ADD.</summary>
        private const string ADD_ACTIVITY_TYPE = @"http://schemas.google.com/AddActivity";
        // Construct your Plus Service, I'll assume a helper for here.
        PlusService plusService = PlusHelper.GetPlusService(credentials);
        Moment addMoment = new Moment();
        ItemScope target = new ItemScope()
            {
                Url = ContentUrl
            };
        addMoment.Type = ADD_ACTIVITY_TYPE;
        addMoment.Target = target;
        Moment response = null;
        try
        {
            response = plusService.Moments.Insert(addMoment, "me",
                MomentsResource.InsertRequest.CollectionEnum.Vault).Execute();
        }
        catch (System.AggregateException)
        {
            /* Occurs when the server can't be seen by Google. */
        }
        catch (Google.GoogleApiException)
        {
            /* Occurs when the server can't be seen by Google. */
        }
