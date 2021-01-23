    public async void SomeMethod()
    {
       var cameraTask = DoCameraWork();
    
       TextBox.Text = "Waiting For camera work";
       SendData();
    
       var result = await cameraTask;
       TextBox.Text = result ? "Camera work finished OK"
                             : "Eek, something is broken";
       ...
    }
