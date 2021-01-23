csharp
var account = new NTAccount(@"NT AUTHORITY\NETWORK SERVICE")
  .Translate(typeof(SecurityIdentifier));
using(PrincipalContext pc = new PrincipalContext(ContextType.Machine))
{
  var user = GroupPrincipal.
    FindByIdentity(pc, IdentityType.Sid, account.Value);
  var group = GroupPrincipal.FindByIdentity(pc, "Administrators");
  group.Members.Add(user);
}
group.Save();  
