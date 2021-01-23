    public class AlteredPictureEditTester : AlteredPictureEdit
    {
        public void RaiseMouseWheelEvent(MouseEventArgs e)
        {
             OnMouseWheel(e);
        }
    }
