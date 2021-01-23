    public class TagAddOnManager
    {
        public static string GetTagCurrentValue<TTag>(ITagParent<TTag> tagParent)
            where TTag : ITag
        {
            // Just an example.
            return tagParent.TagCollection.First().CurrentTag.Description;
        }
    }
