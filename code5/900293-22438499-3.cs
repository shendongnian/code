    public class TestQuestion
    {
    	private string _result;
    	public string Result
    	{
    		get
    		{
    			return _result;
    		}
    		set
    		{
    			_result = value;
    			this.CorrectCount += (this._result == Meta.correctResult ? Meta.incrementCount: 0);
       			this.IncorrectCount += (this._result == Meta.incorrectResult ? Meta.decrementCount : 0);
        		this.ShownCount += (this._result == Meta.shownResult ? Meta.incrementCount : 0);
    		}
    	}
    	public int CorrectCount;
    	public int IncorrectCount;
    	public int ShownCount;
    }
