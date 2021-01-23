	public override void InOrder(MyVisitor<T> visitor)
	{
		if(!IsEmpty(this._left))
		{
			_left.InOrder(visitor);
		}
		visitor.Visit(this);
		visitor.Visit(this);
		if(!IsEmpty(this._right))
		{
			_right.InOrder(visitor);
		}
	}
