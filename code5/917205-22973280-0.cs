    public interface ITool { }
    public interface IWidget : ITool { }
    public class NativeTool { }
    public class NativeWidget : NativeTool { }
    public class MyTool : NativeTool, ITool, INativeTool {
      public MyTool() {
        this.Children = new List<INativeTool>();
      }
      public ITool InterfacePayload { get { return this; } }
      public NativeTool NativePayload { get { return this; } }
      public List<INativeTool> Children { get; set; }
      public NativeTool NativeChild(int index) {
        return this.Children[index].NativePayload;
      }
      public ITool InterfaceChild(int index) {
        return this.Children[index].InterfacePayload;
      }
      public void AddChild(MyTool child) {
        this.Children.Add(child);
      }
      public void AddChild(MyWidget child) {
        this.Children.Add(child);
      }
    }
    public class MyWidget : NativeWidget, IWidget, INativeTool {
      public ITool InterfacePayload { get { return this; } }
      public NativeTool NativePayload { get { return this; } }
    }
    public interface INativeTool {
      // the two payloads are expected to be the same object.  However, the interface cannot enforce this.
      NativeTool NativePayload { get; }
      ITool InterfacePayload { get; }
    }
    public class ToolChild<TPayload>: INativeTool where TPayload : NativeTool, ITool, INativeTool {
      public TPayload Payload { get; set; }
      public NativeTool NativePayload {
        get {return this.Payload;}
      }
      public ITool InterfacePayload {
        get { return this.Payload; }
      }
    }
