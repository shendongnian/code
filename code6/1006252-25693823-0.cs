    public class AnimationController<T> where T : CharacterState
    {
        protected T _character;
        public AnimationController(CharacterState character)
        {
            _character = character;
        }
    }
