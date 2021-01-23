    interface IAccept<T> where T : A
    {
        void Accept(ITaker<T> taker);
    }
    class A : IAccept<A>
    {
    	public string OnlyOnA { get; private set; }
    
    	public virtual void Accept(ITaker<A> ia)
    	{
    		ia.Take(this);
    	}
    }
