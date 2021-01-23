    public class BlogService : IBlogService
        {
            private readonly IBlogRepository _blogRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILogger _logger;
    
            public BlogService(
                IBlogRepository blogRepository,
                IUnitOfWork unitOfWork,
                ILogger logger)
            {
                _blogRepository = blogRepository;
                _unitOfWork = unitOfWork;
                _logger = logger;
            }
    
       public GetAllBlogPostResponse GetAllBlogPost(GetAllBlogPostRequest request)
            {
                var response = new GetAllBlogPostResponse();
                try
                {
                    var blogPosts = _blogRepository.GetAll();
                    if (blogPosts != null)
                    {
                        response.BlogPostViewModel = blogPosts.ConvertToPostListViewModel();
                        response.Success = true;
                        response.MessageType = MessageType.Success;
                        response.Message =       ServiceMessages.GeneralServiceSuccessMessageOnRetrieveInformation;
                        _logger.Log(string.Format(response.Message));
                    }
                    else
                    {
                        response.MessageType = MessageType.Info;
                        response.Message = ServiceMessages.GeneralServiceAlarmMessageOnRetrieveInformation;
                        _logger.Log(string.Format(response.Message));
                    }
                }
                catch (Exception exception)
                {
                    response.Success = false;
                    response.Message = ServiceMessages.GeneralServiceAlarmMessageOnRetrieveInformation;
                    _logger.Log(string.Format(response.Message));
                    _logger.Log(exception.Message);
                }
                return response;
            }
