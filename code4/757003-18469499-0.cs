            Mapper.CreateMap<IDataReader, Question>()
                .ForMember(question => question.PostedBy,
                           o =>
                           o.MapFrom(
                               reader =>
                               new User
                                   {
                                       Username = reader["Firstname"].ToString(),
                                       EmailAddress = reader["Lastname"].ToString()
                                   }));
            Mapper.AssertConfigurationIsValid();
            IEnumerable<Question> mappedQuestions = Mapper.Map<IDataReader, IEnumerable<Question>>(reader);
