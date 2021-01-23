                try
                {
                    await client.LoginAsync("notarealuser@example.com", testpassword);
    
                }
                catch (Exception ex)
                {
                    Assert.That(ex, Is.InstanceOf(typeof (HttpResponseException)));
                }
