            public void AnimateAction(Actions Action, int PositionX, int PositionY)
            {
                Thread AnimationThread = null;
                    AnimationThread = new Thread(new ThreadStart(() => AnimateAction(Action, PositionX, PositionY, 1500)));
                    AnimationThread.Start();
            }
    
            private void AnimateAction(Actions Action, int PositionX, int PositionY, int AnimationDuration)
            {
                if (form.Controls.InvokeRequired)
                {
                    form.Controls.Invoke(new Action(AnimateAction), Action, PositionX, PositionY);
                 }
                 else
                 {
                    Control ActionAnimation = UiHandler.GetInstance().CreateActionItem(Action, PositionX, PositionY);
                    form.Controls.Add(ActionAnimation);
                    ActionAnimation.BringToFront();
                    form.Controls.Remove(ActionAnimation);
                   }
                   
    
            }
