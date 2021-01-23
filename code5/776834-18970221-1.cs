    public dynamic PublishPost(string postId)
    {
        dynamic parameters = new ExpandoObject();
        parameters.published = 1;
        try
        {
            return FacebookClient.Post(string.Format("/{0}", postId), parameters);
        }
        catch (Exception e)
        {
            return null;
        }
    }
