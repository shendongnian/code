    public int RegisterMember(string memberName, string emailAddress, string memberPassword, string memberTypeAlias, string memberGroupName)
    {
            int umbracoMemberId = -1;
            if (!MemberExists(emailAddress))
            {
                IMember newMember = ApplicationContext.Current.Services.MemberService.CreateMember(emailAddress, emailAddress, memberName, memberTypeAlias);
                
                try
                {
                    ApplicationContext.Current.Services.MemberService.Save(newMember);
                    ApplicationContext.Current.Services.MemberService.SavePassword(newMember, memberPassword);
                    ApplicationContext.Current.Services.MemberService.AssignRole(newMember.Id, memberGroupName);
                    umbracoMemberId = newMember.Id;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to create new member " + ex.Message);
                }
            }
            return umbracoMemberId;
    }
    public bool MemberExists(string emailAddress)
    {
            return (ApplicationContext.Current.Services.MemberService.GetByEmail(emailAddress) != null);
    }
