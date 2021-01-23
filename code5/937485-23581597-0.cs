    public class AccommodationImageModelComparer : IEqualityComparer<AccommodationImageModel>
    {
    	public bool Equals(AccommodationImageModel x, AccommodationImageModel y)
    	{
    	    if(x == null && y == null)
    		   return true;
    	    
    		return x.Id == y.Id;
    	}
    	
    	public int GetHashCode(AccommodationImageModel model)
        {
            return model.Id.GetHashCode();
        }
    }
