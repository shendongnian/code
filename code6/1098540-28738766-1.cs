    class TransitionNextAction: TriggerAction<Slideshow>
    {
        protected override void Invoke(object o)
        {
            this.AssociatedObject.TransitionNext();
        }
    }
