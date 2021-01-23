    // Service
    public async Task<ImageSource> GetImage(object key, CancellationToken cancellationToken);
    // ViewModel
    INotifyTaskCompletion<ImageSource> Image { get; private set; }
    ...
    Image = NotifyTaskCompletion.Create(GetImage(key, token));
    // View
    <Image Source="{Binding Image.Result}" />
