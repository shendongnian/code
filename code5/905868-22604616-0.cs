    namespace CPersoanaNameSpace
    {
       [Guid("8578CEB3-6C04-4FC2-BB80-FB371A9F")]
       [ComVisible(true)]
       public interface ICPersoanaCOM
       {
    
          [DispId(1)]
          void Name(out string name);
    
          [DispId(2)]
          void Profession(out string profession);
    
          [DispId(3)]
          void Age(out int age);
        }
        }
