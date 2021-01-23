    public class XPanel : Panel {
       Control previousParent;
       protected override void OnParentChanged(EventArgs e){
         base.OnParentChanged(e);
         if(Parent != previousParent){
           if(Parent != null) Parent.Paint += ParentPaint;
           if(previousParent != null) previousParent.Paint -= ParentPaint;
           previousParent = Parent;
         }
       }
       private void ParentPaint(object sender, PaintEventArgs e){
        //Draw your border here
       }
       protected override void OnSizeChanged(EventArgs e){
          base.OnSizeChanged(e);
          if(Parent!=null) Parent.Invalidate();
       }
       protected override void OnLocationChanged(EventArgs e){
          base.OnLocationChanged(e);
          if(Parent != null) Parent.Invalidate();
       }
    }
