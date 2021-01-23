    Mapper.CreateMap<ModelChild, DayViewModel>()
        .ConstructUsing(context =>
        {
            var key = ((ModelChild) context.SourceValue).Started;
            var daysCollection = (SortedSet<DayViewModel>) context.Parent.DestinationValue;
            var dayViewModel = daysCollection.FirstOrDefault(d => d.Date == key);
            if (dayViewModel == null)
            {
                dayViewModel = new DayViewModel
                {
                    Date = key
                };
                daysCollection.Add(dayViewModel);
            }
            dayViewModel.Children.Add(Mapper.Map<ChildViewModel>(context.SourceValue));
            return dayViewModel;
        })
        .ForAllMembers(d => d.Ignore());
