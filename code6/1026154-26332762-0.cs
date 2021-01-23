    public class Rock : Item
    {
        Texture2D texture;  // This isn't initialized so it is null?
        public Rock()
        {
            this.Texture = texture;  // Here the assumed null is assigned to base class Texture
            ItemName = "rock";
            ItemType itemType = ItemType.craft;
        }
        ...
