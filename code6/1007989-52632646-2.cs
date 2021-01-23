    catch (Exception EX)
    {
    	if (!(EX is System.Threading.ThreadAbortException))
    	{
    		ctx.Response.Write(EX.ToString());
    	}
    }
