    public partial class Game
    {
        public static Game Instance { get; set; }
        public Image IdleAnimation { get; set; }
        static Game() {
            Game.Instance = new Game();
            Game.Instance.Init();
        }
    
        private void Init()
        {
            IdleAnimation = new Image("Filepath\\filepath\\filpath");
        }
        ...
    }
    class Character : IGameObject
    {
        Image CharacterIdleAnimation;
    
        public Character()
        {
           CharacterIdleAnimation = Game.Instance.IdleAnimation;
        }
        ...
    }
