    [TestClass]
    public class MembershipStatusInvocationTests
    {
        [TestMethod]
        public void CreateMemberShouldReturnMembershipCreateStatusEnum()
        {
            var client = new MembershipServiceClient();
            var response = client.CreateMember(new ApplicationUser {ReturnSuccess = true});
            
           Assert.IsInstanceOfType(response.Status, typeof(System.Web.Security.MembershipCreateStatus));
        }
    }
