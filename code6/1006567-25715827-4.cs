    public interface IDesignerComponent
    {
        int X { get; set; }
        int Y { get; set; }
        int Height { get; set; }
        int Width { get; set; }
    }
    
    public class ComponentModel : IDesignerComponent { ... }
    public class ConnectorModel: IDesignerComponent { ... }
    public class OverlayModel: IDesignerComponent { ... }
