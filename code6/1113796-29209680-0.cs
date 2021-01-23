    @model IEnumerable<Tag>
     
    @{
        var tags = Model != null ? Model.ToList() : new List<Tag>();
        var tagsCount = tags.Count;
    }
    
    @for (int i = 0; i < tagsCount; i++)
    {
        @tags[i].Name
        if (i < tagsCount - 1)
        {
            <text> | </text>
        }
    }
