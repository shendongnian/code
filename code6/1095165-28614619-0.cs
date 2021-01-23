    internal override bool EmitTimeZoneHeader
    {
        get
        {
            foreach (TServiceObject serviceObject in this.Items)
            {
                // BEGIN MODIFICATION
                // Handle reply/forward case specially
                if (serviceObject is ResponseMessage)
                {
                    return true;
                }
                // END MODIFICATION
    
                if (serviceObject.GetIsTimeZoneHeaderRequired(false /* isUpdateOperation */))
                {
                    return true;
                }
            }
    
            return false;
        }
    }
