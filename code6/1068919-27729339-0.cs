    public static IEnumerable<AttachLabel> GetAttachLabel()
    {            
    	Entities db = new Entities();
    	foreach (var item in db.tblAttachLabels)
    	{
    		AttachLabel attachLabel = new AttachLabel()
    		{
    			ID = item.ID,
    			Text = item.Text
    		};
    		yield return attachLabel ;
    	}
        // Ends the iteration.
    	yield break;
    }
