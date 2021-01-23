    // this goes in the Forms project
    public class CustomLabel : Label{
      // make it bindable, shortened for simplicity here
      public double LineHeight {get;set;}
    }
    
    // this goes in the iOS project, another one in the Android project
    // notice the attribute is before the namespace
    [assembly: ExportRendererAttribute (typeof(CustomLabel), typeof(CustomLabelRenderer))]
    namespace MyNamespace{
    public class CustomLabelRenderer: LabelRenderer
      protected override void OnElementChanged (ElementChangedEventArgs<Frame> e){
        base.OnElementChanged(e);
      // sample only; expand, validate and handle edge cases as needed
        ((UILabel)base.Control).Font.LineHeight = ((CustomLabel)this.Element).LineHeight;
      }
    
      // if your property is bindable you can handle changes in this method:
      // protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
    }
