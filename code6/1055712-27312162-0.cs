    public async void PushSubscription(Subscription subscription)
    {
        try
        {
            string json = JsonConvert.SerializeObject(subscription);
                    
            using (HttpClient client = new HttpClient())
            {
                await client.PutAsync(apiUrl, new StringContent(json, Encoding.UTF8, "application/json"));
            }
    
            MessageBox.Show("Ik geraak hier");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
