      public class TouchPad : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler 
        {
        	public Vector2 virtualAxes;
        	
        	private Vector2 imagePad;
    void Start()
    	{
    		imagePad = GetComponent<RectTransform>().sizeDelta;
    	}
    public void OnDrag(PointerEventData data)
    	{
    		imageColor.color = new Color (1f, 1f, 1f, 1f);
    
    		int deltaPositionX = (int)(data.position.x - transform.position.x);
    		deltaPositionX = Mathf.Clamp (deltaPositionX, -(int)(imagePad.x/2), (int)(imagePad.x/2));
    
    		int deltaPositionY = (int)(data.position.y - transform.position.y);
    		deltaPositionY = Mathf.Clamp (deltaPositionY, -(int)(imagePad.y/2), (int)(imagePad.y/2));
    		
    		virtualAxes = new Vector2 (deltaPositionX / (imagePad.x/2), deltaPositionY / (imagePad.y/2));
    	}
    
    	public void OnPointerUp(PointerEventData data)
    	{
    		virtualAxes = Vector2.zero;
    		imageColor.color = new Color (1f, 1f, 1f, 0.15f);
    	}
    
    	public void OnPointerDown(PointerEventData data)
    	{
    
    	}
