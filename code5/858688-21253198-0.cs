    public async void LoadProfile()
    		{
    			try
    			{
    				LiveAuthClient auth = new LiveAuthClient();
    				LiveLoginResult initializeResult = await auth.InitializeAsync();
    				try
    				{
    					LiveLoginResult loginResult = await auth.LoginAsync(new string[] { "wl.basic" });
    					if (loginResult.Status == LiveConnectSessionStatus.Connected)
    					{
    						LiveConnectClient connect = new LiveConnectClient(auth.Session);
    						LiveOperationResult operationResult = await connect.GetAsync("me");
    						dynamic result = operationResult.Result;
    						if (result != null)
    						{
    							this.pageTitle.Text = string.Join(" ", "Hello", result.name, "!");
    						}
    						else
    						{
    							this.pageTitle.Text = "Error getting name.";
    						}
    					}
    				}
    				catch (LiveAuthException exception)
    				{
    					this.pageTitle.Text = "Error signing in: " + exception.Message;
    				}
    				catch (LiveConnectException exception)
    				{
    					this.pageTitle.Text = "Error calling API: " + exception.Message;
    				}
    			}
    			catch (LiveAuthException exception)
    			{
    				this.pageTitle.Text = "Error initializing: " + exception.Message;
    			}
    
    		}
