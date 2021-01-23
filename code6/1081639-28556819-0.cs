    IEnumerator GetSales()
    {   
        int result = -1;
        ParseQuery<ParseObject> USQuery = ParseObject.GetQuery ("Sales").WhereEqualTo ("transactionType", "Purchase").WhereGreaterThan ("createdAt",DateTime.Now.AddDays(-1));
        USQuery.CountAsync().ContinueWith(t =>
        {
            result=t.Result;  
        });
        while (result == -1) yield return new WaitForSenOfFrame();
        labelUSSale.text=result.ToString();
    }
