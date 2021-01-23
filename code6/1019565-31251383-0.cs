    <Popup x:Name="popup">
        <Popup.InputBindings>
           <KeyBinding Key="Escape" Command="Close" />
           <KeyBinding Key="Enter" Command="{Binding NewDateSelectedCommand}" />
        </Popup.InputBindings>
    </Popup>
    public void ShowPopup()
    {
        this.popup.IsOpen = true;
        this.popup.Focus();
    }
