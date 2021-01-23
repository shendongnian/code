    public class MyProp: PropBase
    {
	 private double? _prop1;
	 private double? _prop2;
	
	 public double Prop10 { get; set; }
	 public double? Prop1
	 {	 
		get
		{
			if(!this._prop1.HasValue)
				this._prop1 = 0;
			
			return this._prop1;
		}
		set
		{
			this._prop1 = value;
		} 
	 }
     public int? Prop2
     {	 
		get
		{
			if(!this._prop2.HasValue)
				this._prop2 = 0;
			
			return this._prop2;
		}
		set
		{
			this._prop2 = value;
		} 
	 }    
    }
