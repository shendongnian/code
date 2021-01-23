    public class Character
    {
        public Image CharacterIdleAnimation { get; private set; }
        public Character()
        {
            this.CharacterIdleAnimation = Animations.IdleAnimation;
        }
    }
