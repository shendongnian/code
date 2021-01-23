    class MyClaim {
    	private Claim _claim;
    	public MyClaim(string type, string value, string valueType, string issuer, string originalIssuer) {
            _claim = new Claim(type, value, valueType, issuer, originalIssuer);
    	}
    	public Claim Value { get {
    			return _claim;
    		}
    	}
    }
    Claim claim = JsonConvert.DeserializeObject<MyClaim>(json).Value;
