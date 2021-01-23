    public class ButtonNode : System.Windows.Controls.Button
    {
        private System.Windows.Controls.Button _button;
        public ButtonNode(System.Windows.Controls.Button btn) : base() { this._button = btn; }
        public NodeInfo NodeInfo { get; set; }
    }
    public interface INodeInfo { ObjectType Type { get; } }
    [XmlInclude(typeof(ConcreteNodeInfo1))]
    public abstract class NodeInfo : INodeInfo
    {
        public NodeInfo() { }
        [XmlIgnore] private bool isMovable;
        public abstract ObjectType Type { get; }
        public double X { get; set; }
        public double Y { get; set; }
        public string NodeName { get; set; }
    }
    public class ConcreteNodeInfo1 : NodeInfo 
    {
        public ConcreteNodeInfo1() : base () { }
        public override ObjectType Type { get { return ObjectType.ObjectType1; }
    }
  
