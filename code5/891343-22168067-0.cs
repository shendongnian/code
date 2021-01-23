    public class MemberManager 
    {
      public MemberService MemberService {get;set;}
    
      public MemberViewModel GetMember(int id)
      {
          var domainModel = MemberService.GetMember(id);      
          return new MemberViewModel { FullName = domainModel.FullName };
      }
    
      public bool UpdateMember(MemberViewModel viewModel)
      {
          MemberService.Update(new MemberDomainModel { Id = viewModel.Id, FullName = viewModel.FullName });
    
         return true; // all good.
      }
    }
