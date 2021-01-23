    public class DragHangler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public bool IsDragable;
	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData)
	{
		if (!IsDragable)	return;
		Debug.Log ("OnBeginDrag:Do something");
	}
	#endregion
	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData)
	{
		if (!IsDragable)	return;
		Debug.Log ("OnDrag: Do something");
	}
	#endregion
	#region IEndDragHandler implementation
	public void OnEndDrag (PointerEventData eventData)
	{
        if (!IsDragable) return;
		Debug.Log ("OnEnd: Do something");
	}
	#endregion
    }
