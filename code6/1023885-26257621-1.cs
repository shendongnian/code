        public class Opportunity
        {
            public string Title { get; set; }
            public string Location { get; set; }
            public DateTime StartDate { get; set; }
        }
    
        public class OpportunityDto
        {
            public string Title { get; set; }
            public string Location { get; set; }
            [IgnoreMap]
            public DateTime StartDate { get; set; }
        }
    
        public class Saver
        {
            public void CreateOpportunity(OpportunityDto dto)
            {
                var newOpportunity = new Opportunity();//You'll need some database logic here
                MapProperties(dto, newOpportunity);
                //Add save/create logic
            }
    
            public void UpdateOpportunity(OpportunityDto dto)
            {
                var existingUpportunity = new Opportunity();//you'll need some database query logic here
                MapProperties(dto, existingUpportunity);
                //Add save/update logic
            }
    
            public void MapProperties(OpportunityDto dto, Opportunity target)
            {
                Mapper.CreateMap<OpportunityDto, Opportunity>()
                      .ForAllMembers(opt => opt.Condition(srs => !srs.IsSourceValueNull));
                Mapper.Map<OpportunityDto, Opportunity>(dto, target);
                target.Startdate = dto.StartDate;//Insert more logic & mumbo jumbo here
                //Or manually :
                //target.Title = dto.Title;
                //target.Location = dto.Location;
                //target.StartDate = dto.StartDate;
            }
        }
