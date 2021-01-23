    public void ProcessRequest(HttpContext context)
    {
        string imageName = context.Request["imageName"]; //make sure to handle case when this param is missing
        string saveTo = string.Format(@"C:pathtoImage\images\{0}", imageName);
        ...
