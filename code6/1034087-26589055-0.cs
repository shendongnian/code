	if(obj is Moving)
	{
		var objectAsMoving = obj as Moving; //or (Moving)obj;
		objectAsMoving.Y += objectAsMoving.Yspeed;
		objectAsMoving.Yspeed++;
	}
