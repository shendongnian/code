    @using System.Linq;
    ...
    public TagDisplayText
    {
        get
        {
            return string.Join(", ", Tags.Select(x => x.Name));
        }
    }
