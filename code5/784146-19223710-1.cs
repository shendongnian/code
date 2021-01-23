    public class CalendarEventProfile : AutoMapper.Profile
    {
        public override void Configure()
        {
            CreateMap<CalendarEvent, CalendarEventForm>()
                //.ForMember(d => d.Title, o => o.MapFrom(s => s.Title)) //redundant, not necessary
                .ForMember(d => d.EventDate, o => o.MapFrom(s => s.EventDate.Date))
                .ForMember(d => d.EventHour, o => o.MapFrom(s => s.EventDate.Hour))
                .ForMember(d => d.EventMinute, o  => o.MapFrom(s => s.EventDate.Minute))
            ;
        }
    }
