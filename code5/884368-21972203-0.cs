    public void OnTouchBegin( object sender, TouchEventArgs e ){
        foreach( TouchPoint point in e.TouchPoints ){
            firstTouchPosition = new Vector2( point.Position.x, point.Position.y );
		}
	}
    public void OnTouchContinue( object sender, TouchEventArgs e ){
        foreach( var point in e.TouchPoints ){
            secondTouchPosition  = new Vector2( point.Position.x, point.Position.y );
	        currentTouchMovement = new Vector2( ( secondTouchPosition.x - firstTouchPosition.x ),
	        ( secondTouchPosition.y - firstTouchPosition.y ));
            currentTouchMovement.Normalize( );
		}
    }
    public void OnTouchEnd( object sender, TouchEventArgs e ){
		hasTouchEnded = true;
    }
