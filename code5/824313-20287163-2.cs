    public class XPanel : Panel {
       public XPanel(){
         BorderWidth = 5;
       }
       Control previousParent;
       public float BorderWidth {get;set;}
       protected override void OnParentChanged(EventArgs e){
         base.OnParentChanged(e);
         if(Parent != previousParent){
           if(Parent != null) Parent.Paint += ParentPaint;
           if(previousParent != null) previousParent.Paint -= ParentPaint;
           previousParent = Parent;
         }
       }
       private void ParentPaint(object sender, PaintEventArgs e){
         using(Pen p = new Pen(Color.Blue, BorderWidth)){
           float halfPenWidth = BorderWidth / 2;
           var borderRect = new RectangleF(Left - halfPenWidth, Top - halfPenWidth,
                                          Width + BorderWidth, Height + BorderWidth);
           e.Graphics.DrawRectangle(p, borderRect); 
         }
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
