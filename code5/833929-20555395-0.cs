    struct Point
    {
        public float X { get; set; }
        public float Y { get; set; }
    }
    
    struct Size
    {
        public float Width { get; set; }
        public float Height { get; set; }
    }
    
    struct Rectangle
    {
        public Point Location { get; set; }
        public Size Size { get; set; }
    }
    
    private Point origin; // startX/Y
    private Point position; // posX/Y
    private Size previousSize; // previousWidth/Height
    
    private int index = 0;
    private int currentColumn;
    
    private static readonly string QuestItemCardPrefix = "QuestItemCard";
    
    private void AddCard(int index, int column, Size size)
    {
        var card = GameObject.Instantiate(pfCard00);
        var cardSprite = card.GetComponentInChildren<PackedSprite>();
    
        card.name = QuestItemCardPrefix + index.ToString();
        card.transform.parent = goCardContainer.transform;
        cardSprite.height = size.Height;
    
        if (currentColumn != column) 
        {
            position.X += width;
    
            position.Y = 0;
            previousSize.Height = 0;
        }
    
        // placement
        position.Y += (previousSize.Height / 2) + (size.Height / 2);
        card.transform.localPosition = new Vector3(origin.X + position.X, origin.Y - position.Y, card.transform.position.z);
    
        if (currentColumn != column)
        {
            previousSize.Width = size.width;
    
            currentColumn = column;
        }
    
        previousSize.Height = size.height;
    }
