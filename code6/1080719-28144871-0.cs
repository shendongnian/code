    public class RecordProfile : Profile
    {
        protected override void Configure()
        {
            base.CreateMap<AddRecordViewModel, Record>().ReverseMap();
        }
    }
