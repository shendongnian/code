    public class EmployeeObject {
      public Int32 Id { get; set; }
      public string SubTitle { get; set; }
      public string Desc { get; set; }
      public bool Active { get; set; }
      public string ActiveDateTime { get; set; }
      public override bool Equals(object o){
         EmployeeObject e = o as EmployeeObject;
         if(e == null) return false;
         return Id == e.Id && SubTitle == e.SubTitle && Desc == e.Desc 
                && Active == e.Active && ActiveDateTime == e.ActiveDateTime; 
      }
      public override int GetHashCode(){
         return Id.GetHashCode() ^ SubTitle.GetHashCode() ^ Desc.GetHashCode()
                ^ Active.GetHashCode() ^ ActiveDateTime.GetHashCode();             
      }
    }
