    public class Custom_DragDropItem : UIDragDropItem {
    
    	public delegate void DragDropDelegate(GameObject TargetObject);
    
    	public DragDropDelegate onDragDrop;
    }
