    public object BeforeCall(string operationName, object[] inputs)
    {
			var request = inputs[0];
			var typeOfRequest = request.GetType();
			if (!typeOfRequest.GetCustomAttributes(typeof(CustomAttribute), false).Any())
			{
				return null;
			}
    }
