    public bool IsDone
        {
            get 
            {
                return ActionSteps.Count(x => x.IsDone) == ActionSteps.Count;
            }
        }
