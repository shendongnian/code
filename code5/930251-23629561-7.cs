    public class UsersModule : NancyModule
    {
        public UsersModule()
            : base("/users")
        {
            Get["/profile/{name}"] = _ => 
            {
                var request = this.Bind<FooRequest>();
                var user = UserRepository.GetByName(requestName);
                if (user == null)
                {
                    var error = new Response();
                    error.StatusCode = HttpStatusCode.BadRequest;
                    error.ReasonPhrase = "Invalid user identifier.";
                    return error;
                }
                if (false == user.CanAccessModule())
                {
                    var error = new Response();
                    error.StatusCode = HttpStatusCode.Unauthorized;
                    error.ReasonPhrase = "User has insufficient priviledges.";
                    return error;
                }
                var userDto = CreateUserDto(user);
                var viewDto = new {
                    Message = string.Format("Hello {0}", user.FullName),
                    User = userDto
                };
                return Negotiate
                        .WithAllowedMediaRange(MediaRange.FromString("text/html"))
                        .WithAllowedMediaRange(MediaRange.FromString("application/json"))
                        .WithModel(viewDto)  // Model for 'text/html'
                        .WithMediaRangeModel(
                              MediaRange.FromString("application/json"), 
                              userDto); // Model for 'application/json';
            }
        }
    }
