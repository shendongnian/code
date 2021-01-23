    public class GetUserAndDetailsImplementation : GetEUserAndDetails 
    {
    	private Metastorm.Runtime.Types.Text _paramFullNameLike;
    	public override Metastorm.Runtime.Types.Text paramFullNameLike
    	{
    		get { return _paramFullNameLike; }
    	}
    	
    	public void SetParamFullNameLike(Metastorm.Runtime.Types.Text text)
    	{
    		_paramFullNameLike = text;
    	}
    }
