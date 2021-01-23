    private async void button1_Click(object sender, EventArgs e)
            {
                await ClickAsync();
            }
    
            private async Task<int> AccessTheWebAsync()
            {
                 
                return await Task.Run(() =>
                    {
                        //Some heavy work
                        Task.Delay(10000);
                        return 3; //replace with real result
                    });
    
            }
    
            public async Task ClickAsync()
            {
                int contentLength = await AccessTheWebAsync();
    
                label1.Text = String.Format("\r\nLength of the downloaded string: {0}.\r\n", contentLength);
            }
        }
