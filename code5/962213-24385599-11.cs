            model.UserList = new List<UserModel>();
            AutoMapper.Mapper.CreateMap<User, UserModel>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID));
            model.UserList = AutoMapper.Mapper.Map(query.ToList(), model.UserList);
            foreach ( var user in model.UserList )
            {
               var custList = _customerRepository.GetCustomersForUser(user.ID).ToList();
               user.CustomerList  = AutoMapper.Mapper.CreateMap<custList, IEnumerable<CustomerModel>>();             
            }
            return model;
