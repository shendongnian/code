    public async void RemoveItem(SomeItem item){
        IsRemoving = true;
        await Task.Delay(1000);
        <Your collection>.Remove(item);
        IsRemoving = false;
    }
