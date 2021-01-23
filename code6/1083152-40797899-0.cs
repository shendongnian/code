    public interface ICameraProvider
    {
        Task<CameraResult> TakePhotoAsync();
        Task<CameraResult> PickPhotoAsync();
    }
    private Command AttachImage 
    {
    var camera = await DependencyService.Get<ICameraProvider>().TakePhotoAsync();
    }
