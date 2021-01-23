    private async void searchGzBTN_Click(object sender, RoutedEventArgs e)
    {
        try
        {
           // ... 
    
           // server1
           var query1 = ExecuteQueryTapAsync(clientctx);
           // ...
        
           // server2
           var query2 = ExecuteQueryTapAsync(clientctx);
           // ...
    
           // asynchronously await both results
           await Task.WhenAll(query1, query2);
           // ...
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
