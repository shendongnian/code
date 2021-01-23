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
    }
