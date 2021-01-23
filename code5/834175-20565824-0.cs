    public virtual string GetLocalFileName(HttpContentHeaders headers)
    {
        if (headers == null)
        {
            throw Error.ArgumentNull("headers");
        }
    
        return String.Format(CultureInfo.InvariantCulture, "BodyPart_{0}", Guid.NewGuid());
    }
