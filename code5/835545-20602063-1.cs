    public interface IGame
    {
        public Image IdleAnimation { get; set; }
        public void Init();
    }
    public partial class Game : IGame
    {
        public Image IdleAnimation { get; set; }
   
        private void Init()
        {
            IdleAnimation = new Image("Filepath\\filepath\\filpath");
        }
        ...
    }
    class Character : IGameObject
    {
        Image CharacterIdleAnimation;
    
        public Character(IGame game)
        {
           CharacterIdleAnimation = game.IdleAnimation;
        }
        ...
    }
