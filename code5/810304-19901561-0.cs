    public class UpdateUserProfileImageCommandHandler 
        : ICommandHandler<UpdateUserProfileImageCommand>
    {
        private readonly IFileService fileService;
        public UpdateUserProfileImageCommandHandler(IFileService fileService)
        {
            this.fileService = fileService;
        }
        public void Handle(UpdateUserProfileImageCommand command)
        {
             var user = userRespository.GetById(command.Id);
    
             this.fileService.DeleteFile(user.ProfileImageUri);
             command.ImageUri = this.fileService.Upload(generatedUri, command.Image);
             user.ProfileImageUri = command.ImageUri;     
        }
    }
