    try
    {
        var token = await client.Core.OAuth2.TokenAsync(authCode);
    }
    catch (AggregateException aex)
    {
        // set a breakpoint on the opening curly brace and check the
        // variable "aex".
    }
