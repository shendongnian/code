    public class ToolbarItemInfo
    {
        public string FamilyName { get; private set; }
        public Image ItemIcon { get; private set; }
        public string DisplayName { get; private set; }
        public Action<ToolbarItemInfo> OnFired { get; private set; }
    }
