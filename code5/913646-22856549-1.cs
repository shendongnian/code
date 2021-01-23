    Mapper.CreateMap<Activity, D.Activity>()
                .ForMember(dto => dto.ActivityID, options => options.MapFrom(activity => activity.Id))
                .ForMember(dto => dto.ClientID, options => options.MapFrom(activity => activity.ClientId))
                .ForMember(dto => dto.ActivityTypeID, options => options.MapFrom(activity => activity.ActivityTypeId))
                .ForMember(dto => dto.Description, options => options.MapFrom(activity => activity.Description))
                .ForMember(dto => dto.StartTime, options => options.MapFrom(activity => activity.StartTime))
                .ForMember(dto => dto.StopTime, options => options.MapFrom(activity => activity.StopTime))
                .ForMember(dto => dto.IsBillable, options => options.MapFrom(activity => activity.IsBillable))
                .ForMember(dto => dto.WorkOrderID, options => options.MapFrom(activity => activity.WorkOrderId))
                .ForMember(dto => dto.PerformedByEmployeeID, options => options.MapFrom(activity => activity.PerformedByEmployeeId))
                .ForMember(dto => dto.ProductLines, options => options.Ignore())
                .AfterMap((src, dest) =>
                    {
                        foreach (var productLine in src.ProductLines)
                        {
                            dest.ProductLines.Add(Mapper.Map<D.ProductLine>(productLine));
                        }
                    });
