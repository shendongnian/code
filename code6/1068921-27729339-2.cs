    public static IEnumerable<AttachLabel> GetAttachLabel()
    {            	
    	using(Entities db = new Entities())
    	{
    		foreach (var item in db.tblAttachLabels)
    		{
    			AttachLabel a = new AttachLabel()
    			{
    				ID = item.ID,
    				Text = item.Text
    			};
    			yield return a;
    		}
    	}
    	yield break;
    }
