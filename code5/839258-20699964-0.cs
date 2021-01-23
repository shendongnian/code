    private static bool StringParsesAsInt(string value)
	{
		int result;
		return Int32.TryParse(value, out result);
	}
....
    if StringParsesAsInt(vatiraleparamter) 
    {
    }
