    [DbFunction("NaturalGroundingVideosModel.Store", "fn_GetRatingValue")]
    public float? DbGetValue(float? height, float? depth, float ratio) {
        List<ObjectParameter> parameters = new List<ObjectParameter>(3);
        parameters.Add(new ObjectParameter("height", height));
        parameters.Add(new ObjectParameter("depth", depth));
        parameters.Add(new ObjectParameter("ratio", ratio));
        var lObjectContext = ((IObjectContextAdapter)this).ObjectContext;
        var output = lObjectContext.
                CreateQuery<float?>("NaturalGroundingVideosModel.Store.fn_GetRatingValue(@height, @depth, @ratio)", parameters.ToArray())
            .Execute(MergeOption.NoTracking)
            .FirstOrDefault();
        return output;
    }
