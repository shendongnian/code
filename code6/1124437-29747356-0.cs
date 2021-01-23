     AutoMapper.Mapper.CreateMap<User, Models.User>()
           .ForMember(x => x.Person, opt => opt.ResolveUsing(new personResolver(loadRepository)).FromMember(x => x.PersonId));
    public class personResolver : ValueResolver<int, Models.Person>
        {
            private DatabaseLoadRepository loadRepository;
            public personResolver(DatabaseLoadRepository repo)
            {
                this.loadRepository = repo;
            }
            protected override Models.Person ResolveCore(int personId)
            {
                return loadRepository.FindOne<Models.Person>(x => x.Id == personId);
            }
        }
