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
                    throw new ArgumentException(
                        "Invalid user identifier.");
                }
                if (false == user.CanAccessModule())
                {
                    throw new UnauthorizedAccessException(
                        "User has insufficient priviledges.");
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
