    if (context.HttpContext.Response.IsClientConnected)
    {
    	WriteEntityRange(context.HttpContext.Response, RangesStartIndexes[i], RangesEndIndexes[i]);
    	if (MultipartRequest)
    				context.HttpContext.Response.Write("\r\n");
    	context.HttpContext.Response.Flush();
    }
