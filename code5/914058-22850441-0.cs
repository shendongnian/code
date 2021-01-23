      public virtual void Subscribe(Func<ITCardBase, int> myMethodName)
        {
            TCardClick = null;//THIS FIXED EVERYTHING
            TCardClick += myMethodName.Invoke;          
        }
