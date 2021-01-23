    IResponse response = msgSetRs.ResponseList.GetAt(0);
    if(response.StatusCode != 0)
    {
        // There was an error. response.StatusCode has the error number
        // response.StatusMessage has the error description.
    }
    else
    {        
        ICheckRetList checkRetList = (ICheckRetList)response.Detail;
        .
        .
        .
    }
