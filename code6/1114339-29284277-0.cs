    using System.Management.Automation;
    public class Whatever {
       public string One { get { return "This is one"; } }
       public string Two { get { return "This is two"; } }
       public string Three { get { return "This is three"; } }
       public string Four { get { return "This is four"; } }
  
       public static PSObject Get() {
  
          var w = new Whatever();
          var pso = new PSObject(w);
          var display = new PSPropertySet("DefaultDisplayPropertySet",new []{"One","Two"});
          var mi = new PSMemberSet("PSStandardMembers", new[]{display});
          pso.Members.Add(mi);
  
          return pso;
       }
    }
