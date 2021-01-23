    AutoMapper.Mapper.CreateMap<Person, Models.Person>()
                    .ForMember(x => x.Language, opt => opt.ResolveUsing(new LanguageCodeResolver(loadRepository)).FromMember(x => x.LanguageId));
    public class LanguageCodeResolver : ValueResolver<string, Dicom.Expense.Models.Language>
    {
        private IDatabaseLoadRepository loadRepository;
        public LanguageCodeResolver(IDatabaseLoadRepository loadRepository)
        {
            this.loadRepository = loadRepository;
        }
        protected override Models.Language ResolveCore(string languageCode)
        {
            return loadRepository.FindOne<Models.Language>(x => x.LanguageId == languageCode);
        }
    }
