    class MyEncoderFallback: EncoderFallback
    {
    	public override int MaxCharCount { get { return 11; } }
    	public override EncoderFallbackBuffer CreateFallbackBuffer()
    	{
    		return new MyEncoderFallbackBuffer();
    	}
    }
    
    class MyEncoderFallbackBuffer: EncoderFallbackBuffer
    {
    	private List<char> _encoded = new List<char>();
    	private int _nextIndex = 0;
    	
    	public override int Remaining { get { return _encoded.Count - _nextIndex; } }
    	
    	public override bool Fallback(char unknownChar, int index)
    	{
    		var encoded = String.Format("#{0:d4}:{1:x4}#", index, (int)unknownChar);
    		
    		_encoded.Clear();
    		_encoded.AddRange(encoded.AsEnumerable());
    		
    		_nextIndex = 0;
    		
    		return true;
    	}
    	
    	public override bool Fallback(char charUnknownHigh, char charUnknownLow, int index)
    	{
    		return false;
    	}
    	
    	public override char GetNextChar()
    	{
    		char next;
    		if(_nextIndex < _encoded.Count)
    		{
    			next = _encoded[_nextIndex];
    			_nextIndex += 1;
    		}
    		else 
    		{
    			next = default(char);
    		}
    		
    		return next;
    	}
    	
    	public override bool MovePrevious()
    	{
    		bool result;
    		
    		if(_nextIndex > 0)
    		{
    			_nextIndex -= 1;
    			result = true;
    		}
    		else
    		{
    			result = false;
    		}
    		
    		return result;
    	}
    	
    	public override void Reset()
    	{
    		_encoded.Clear();
    		_nextIndex = 0;		
    	}
    }
