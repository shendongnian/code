    const char separator = ';';
    byte[] inputBytes = { 255, 16, 1 };
    
    StringBuilder sb = new StringBuilder();
    
    foreach (byte b in inputBytes)
    	sb.Append(b).Append(separator);
    
    // remove a separator in a tail
    sb.Remove(sb.Length - 1, 1);
    
    
    var byteArrayActual = sb.ToString()
    		.Split(separator)
    		.Select(x => byte.Parse(x))
    		.ToArray();
    
    Debug.Assert(Enumerable.SequenceEqual(inputBytes, byteArrayActual));
