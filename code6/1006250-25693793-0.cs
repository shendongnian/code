    public class AnimationController<T> where T : CharacterState
    {
        protected T _character;
    
        public AnimationController(T character)
        {
            _character = character;
        }
    
        public void UpdateAnimations() 
        {
            /* call on some CharacterState functions... */
        }
    }
