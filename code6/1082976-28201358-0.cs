    public class MyExtensions
    {
       public static void UpdateTabStop(this TextBox txtBox)
       {
           txtBox.TabStop = !(txtBox.ReadOnly);
       }
       public static void UpdateTabStop(this Form frm)
       {
           foreach (var txtBox in frm.Controls.OfType<TextBox>())
           {
               txtBox.UpdateTabStop();
           }
       }
    }
