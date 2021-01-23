    [ServiceContract]
    public interface IMembershipService
    {
        [OperationContract]
        CreateMemberResponse CreateMember(ApplicationUser userToCreate);
    }
    [DataContract]
    [KnownType(typeof(System.Web.Security.MembershipCreateStatus))]
    public class CreateMemberResponse
    {
        [DataMember]
        public MembershipCreateStatus Status { get; set; }
    }
    [DataContract]
    public class ApplicationUser
    {
        public bool ReturnSuccess { get; set; }
        public ApplicationUser()
        {
            ReturnSuccess = true;
        }
    }
