	bool _pinching = false;
	float _pinchInitialDistance;
	private void HandleTouchInput() 
	{
		while (TouchPanel.IsGestureAvailable)
		{
			GestureSample gesture = TouchPanel.GetGesture();
			if (gesture.GestureType == GestureType.Pinch)
			{
				// current positions
				Vector2 a = gesture.Position;
				Vector2 b = gesture.Position2;
				float dist = Vector2.Distance(a, b);
				
				// prior positions
				Vector2 aOld = gesture.Position - gesture.Delta;
				Vector2 bOld = gesture.Position2 - gesture.Delta2;
				float distOld = Vector2.Distance(aOld, bOld);
				if (!_pinching)
				{
					// start of pinch, record original distance
					_pinching = true;
					_pinchInitialDistance = distOld;
				}
				
				// work out zoom amount based on pinch distance...
				float scale = (distOld - dist) * 0.05f;
				ZoomBy(scale);
			}
			else if (gesture.GestureType == GestureType.PinchComplete)
			{
				// end of pinch
				_pinching = false;
			}
		}
	}
