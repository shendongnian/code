    public class WitchAnimationController : AnimationController<WitchState>
    {    
        public WitchAnimationController(WitchState witch) : base(witch) 
        {}
    
        public void UpdateAnimations() 
        {
            base.UpdateAnimations();
    
            _character.SomeMethodOnWitchState();
        }
    }
