    private static void SplitHalf(string[] identities, IIdentityManagementService GSS)
    		{
    			var count = identities.Count();
    			int half = count / 2;
    			List<string> half1 = new List<string>();
    			List<string> half2 = new List<string>();
    
    			for (int i = 0; i < half; i++)
    			{
    				half1.Add(identities[i]);
    			}
    
    			var halfArray1 = half1.ToArray();
    
    			try
    			{
    				var users = GSS.ReadIdentities(SearchFactor.Sid, halfArray1, QueryMembership.None);
    			}
    			catch (Exception ex)
    			{
    				SplitHalf(halfArray1, GSS);
    			}
    
    			for (int i = half; i < count; i++)
    			{
    				half2.Add(identities[i]);
    			}
    
    			var halfArray2 = half2.ToArray();
    
    			try
    			{
    				var users = GSS.ReadIdentities(SearchFactor.Sid, halfArray2, QueryMembership.None);
    			}
    			catch (Exception ex)
    			{
    				SplitHalf(halfArray2, GSS);
    			}
    		}
