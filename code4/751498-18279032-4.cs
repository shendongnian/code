    public class Bravo
    {
      public void SomeMethod()
      {
        Alpha instance = GetAnInstanceOfAlpha() ; // might be passed as a parameter
        if ( instance.DTestNumber == 3 )
        {
          messagebox.Show('test worked') ;
        }
        return ;
      }
