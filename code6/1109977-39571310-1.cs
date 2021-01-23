    //Profile number one saved in Web layer
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<Question, QuestionModel>();
            CreateMap<QuestionModel, Question>();
            /*etc...*/
        }
    }
     
    //Profile number two save in Business layer
    public class BLProfile: Profile
    {
        public BLProfile()
        {
            CreateMap<BLModels.SubModels.Address, DataAccess.Models.EF.Address>();
            /*etc....*/
        }
    }
