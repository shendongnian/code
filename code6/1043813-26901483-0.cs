    public override string ToString()
    {     
    	if (Rating == 0)
    	{
    		return String.Format("{0}", Title);
    	}
    	else
    	{
    		return String.Format(" {0} Genre : {1},  Rating: {2:d} Stars. ", Title, GenType, Rating);
    	}
    }
