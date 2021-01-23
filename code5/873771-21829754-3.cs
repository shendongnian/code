    public class MyObj
    {
       public void angleEndInteractionEvt(vtkObject sender, vtkObjectEventArgs e) {
          // Do stuff
          if(EndInteractionEvt != null) {
             EndInteractionEvt(sender, e);
          }
       }
    }
