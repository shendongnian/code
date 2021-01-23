    private async void go_Click(object sender, EventArgs e)
    {
        {
            while (GlobalVar.Direction == "down")
            {  
               await Task.Delay(1000); 
               movedown();
            }
            ...
        }
    }
