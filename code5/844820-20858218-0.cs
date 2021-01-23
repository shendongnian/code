    bool result = GetHandleType(handle, handleEntry.OwnerPid, out handleType);
    if (result)
    {
    	switch (handleType)
    	{
    		case SystemHandleType.OB_TYPE_FILE:
    		{
    			// Existing code:
    			string devicePath;
    			....
    		}    		
    		break;
    		
    		case SystemHandleType.OB_TYPE_PROCESS:
    		{
    			// Your code here
    			....
    		}    		
    		break;
    	}
    }
