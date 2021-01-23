    public string GeneratePassword(string input)
    {
    	var add= new byte[] {12,2,17,5,16,31,28,10,16,20,22,1};
    	var subst = new Dictionary<byte, byte> {{58,122},{59,121},{60,120},{61,119},{62,118},{63,117},{64,116},{91,115},{92,114},{93,113},{94,112},{45,111},{96,110}};
    
    	var inputMac = input.Replace(":", "").ToUpperInvariant();
    	if (!Regex.IsMatch(inputMac, "^[A-F0-9]{12}$") || (inputMac == "000000000000"))
    	{
    		return "invalid";
    	}
    	else
    	{
    	    var c="";
    	    for(var b = 0; b < 12; b++)
    		{
    	        var a = (byte)((byte)inputMac[b] + add[b]);
    	        if(subst.ContainsKey(a))
    			{
    	            a=subst[a];
    	        }
    	        c += (char)a;
    	    }
    	    return "2008" + c;
    	}
    }
