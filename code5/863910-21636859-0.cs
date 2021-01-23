    private bool _cancelation_pennding=false;
    private delegate DrawContentHandler(TimePeriod period, Token token)
    private DrawContentHandler _dc_handler=null;
    
    .ctor(){
    	this._dc_handler=new DrawContentHandler(this.DrawContent)
    }
    public void CancelAsync(){
    	this._cancelation_pennding=true;
    }
    public void Draw(){
    	this._dc_handler.BeginInvoke(this.TimePeriod, this.cts.Token)
    }
    private void DrawContent(TimePeriod period, Token token){
    	loop(){
    		if(this._cancelation_pennding)
    		{
    			break;
    		}
    		
    		//DrawContent code here
    	}
    	this._cancelation_pennding=false;
    }
