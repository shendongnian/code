    public class AnimationController 
    {
        public AnimationController(  )
        {
        }
    
        public void UpdateAnimations( CharacterState character ) 
        {
            /* call on some CharacterState functions... */
        }
    }
    public class WitchAnimationController : AnimationController
    {   
        public AnimationController( )
        {
        }
    
        public void UpdateAnimations(WitchState witch ) 
        {
            base.UpdateAnimations(witch );
    
            /* call on some WitchState functions... */
        }
    }
