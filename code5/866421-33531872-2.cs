    private void SubscribeLocalevents()
    {
            this.globalMouseHook.MouseDoubleClick += async (o, args) => await this.MouseDoubleClicked(o, args);
            this.globalMouseHook.MouseDown += async (o, args) => await this.MouseDown(o, args);
            this.globalMouseHook.MouseUp += async (o, args) => await this.MouseUp(o, args);
    }
    private async Task MouseUp(object sender, MouseEventArgs e)
    {
            this.mouseSecondPoint = e.Location;
            if (this.isMouseDown && !this.mouseSecondPoint.Equals(this.mouseFirstPoint))
            {
                await Task.Run(() =>
                {
                    if (this.mainWindow.CancellationTokenSource.Token.IsCancellationRequested)
                        return;
                    SendKeys.SendWait("^c");
                });
                this.isMouseDown = false;
            }
            this.isMouseDown = false;
    }
    private async Task MouseDown(object sender, MouseEventArgs e)
    {
            await Task.Run(() =>
            {
                if (this.mainWindow.CancellationTokenSource.Token.IsCancellationRequested)
                    return;
                this.mouseFirstPoint = e.Location;
                this.isMouseDown = true;
            });
    }
    private async Task MouseDoubleClicked(object sender, MouseEventArgs e)
    {
            this.isMouseDown = false;
            await Task.Run(() =>
            {
                if (this.mainWindow.CancellationTokenSource.Token.IsCancellationRequested)
                    return;
                SendKeys.SendWait("^c");
            });
    }
