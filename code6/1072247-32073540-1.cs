    public void CreateMemberType(IContentTypeComposition parent, string memberTypeAlias)
    {
            IMemberType memberType = new Umbraco.Core.Models.MemberType(parent, memberTypeAlias);
            ApplicationContext.Current.Services.MemberTypeService.Save(memberType);
    }
