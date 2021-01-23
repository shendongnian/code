    namespace Unboxed.Models
    {
      public interface IOrgBase{
        string GetName();
        int GetID();
        IOrgBase GetParent();
        string GetEntityType();
       }   
      [MetadataType(typeof(Level1_Meta))]
      public partial class Level1 : IOrgBase{
       
          #region IOrgBase impl
          public string GetName()
          {
            return Level1Name;
          }
          ....
          #endregion IOrgBase impl
          ...
         }
    }
