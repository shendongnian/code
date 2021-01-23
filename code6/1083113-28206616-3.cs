    private bool _triggerCompleted;
		private const double SideMenuCollapsedLeft = -340;
		private const double SideMenuExpandedLeft = 0;
		private void Sidebar_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
		{
			_triggerCompleted = true;
			double finalLeft = Canvas.GetLeft(Sidebar) + e.Delta.Translation.X;
			if (finalLeft < -340 || finalLeft > 0)
				return;
			Canvas.SetLeft(Sidebar, finalLeft);
			if (e.IsInertial && e.Velocities.Linear.X > 1)
			{
				_triggerCompleted = false;
				e.Complete();
				MoveLeft(SideMenuExpandedLeft);
			}
			if (e.IsInertial && e.Velocities.Linear.X < -1)
			{
				_triggerCompleted = false;
				e.Complete();
				MoveLeft(SideMenuCollapsedLeft);
			}
			if (e.IsInertial && Math.Abs(e.Velocities.Linear.X) <= 1)
				e.Complete();
		}
		private void Sidebar_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
		{
			if (_triggerCompleted == false)
				return;
			double finalLeft = Canvas.GetLeft(Sidebar);
			if (finalLeft > -170)
				MoveLeft(SideMenuExpandedLeft);
			else
				MoveLeft(SideMenuCollapsedLeft);
		}
		private void MoveLeft(double left)
		{
			double finalLeft = Canvas.GetLeft(Sidebar);
			Storyboard moveAnivation = ((Storyboard)RootCanvas.Resources["MoveAnimation"]);
			DoubleAnimation direction = ((DoubleAnimation)((Storyboard)RootCanvas.Resources["MoveAnimation"]).Children[0]);
			direction.From = finalLeft;
			moveAnivation.SkipToFill();
			direction.To = left;
			moveAnivation.Begin();
		}
