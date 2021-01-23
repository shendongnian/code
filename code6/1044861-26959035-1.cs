    namespace SpaceInvaders
    {
      class meteorGenerator
      {
        public Vector2 m_Pos;
        public Vector2 m_Position
        {
            get { return m_Pos; }
            set { m_Pos = value; }
        }
        Texture2D m_Texture { get; set; }
        Texture2D m_MeteorsTex;
        public meteorGenerator(Texture2D vTex, Vector2 vPos)
        {
            m_Position = vPos;
            m_Texture = vTex;
        }
        static List<meteorGenerator> m_MeteorsList = new List<meteorGenerator>();
        static readonly Random rnd = new Random();
        public static void LoadContent(ContentManager Content)
        {
            m_MeteorsTex = Content.Load<Texture2D>(".\\gameGraphics\\gameSprites\\thePlan\\meteorSpawn");
        }
        public static void Update(GameTime gameTime)
        {
            if (m_MeteorsList.Count() < 4)
            {
                m_MeteorsList.Add(new meteorGenerator(m_MeteorsTex, new Vector2(rnd.Next(30, 610), rnd.Next(30, 450))));
            }
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (meteorGenerator m_Meteor in m_MeteorsList)
            {
                spriteBatch.Draw(m_Meteor.m_Texture, m_Meteor.m_Position, Color.White);
            }
        }
    }
}
