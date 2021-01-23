    public class LinkSet
    {
        public List<ItemLink> Links { get; set; }
        public LinkSet(IEnumerable<IItemLinkProvider> items)
        {
            Links = items.Select(i => new ItemLink
                {
                    Title = i.GetTitle(),
                    Subtitle= i.GetSubtitle(),
                    Image = i.GetImage()
                }).ToList();
        }
    }
