        private void ChangeBehaviorState<T>(DependencyObject owner, BehaviorState state) where T : DependencyObject
        {
            DependencyObject root = UIHelper.FindChildOfType<T>(owner);
            if (root == null) return;            
            FluidMoveBehavior b = Interaction.GetBehaviors(root)[0] as FluidMoveBehavior;
            if (b == null) return;
            switch (state)
            {
                case BehaviorState.Attach:
                    b.Attach(root);
                    break;
                case BehaviorState.Detach:
                    b.Detach();
                    break;
            }
        }
