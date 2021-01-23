    public dynamic PublishPost(string postId)
    {
        dynamic parameters = new ExpandoObject();
        parameters.is_published = "true";
        try
        {
            return FacebookClient.Post(string.Format("/{0}", postId), parameters);
        }
        catch (Exception e)
        {
            return null;
        }
    }
