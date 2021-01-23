    public abstract class UIItemBase
    {
        public abstract IEnumerable<UIItemBase> Items { get; }
    }
    public abstract class UIItemContainer : UIItemBase
    {
        [XmlAttribute("id")]  // I put this here because there's no "id" on the "<Item>" entries.  Move to UIItemBase if it makes more sense.
        public string Id { get; set; }
        [XmlElement("TabName", typeof(UITab))]
        [XmlElement("MenuItem", typeof(UIMenu))]
        [XmlElement("Item", typeof(UIItem))]
        // Add an [XmlElement("Name", typeof(Class))] for every subclass that might be here.
        public List<UIItemBase> ItemList { get; set; }
        public override IEnumerable<UIItemBase> Items
        {
            get {
                return ItemList;
            }
        }
    }
    public class UITab : UIItemContainer
    {
        [XmlAttribute("access")]
        public string Access { get; set; }
    }
    [XmlRoot("Menus")]
    public class UIMenu : UIItemContainer
    {
        [XmlAttribute("hidden")]
        public bool Hidden { get; set; }
    }
    public sealed class UIItem : UIItemBase
    {
        [XmlAttribute("index")]
        public int Index { get; set; }
        [XmlText]
        public string Value { get; set; }
        public override IEnumerable<UIItemBase> Items
        {
            get
            {
                return Enumerable.Empty<UIItemBase>();
            }
        }
    }
