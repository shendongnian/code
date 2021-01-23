    public class ColorShifter : MonoBehaviour
    {
    	public float MinDistance = 1f;
    	public float MaxDistance = 10f;
    
    	public Transform Target;
    	protected SpriteRenderer SpriteRenderer;
    
    	protected void Awake()
    	{
    		SpriteRenderer = GetComponent<SpriteRenderer>();
    	}
    
    	protected void Update()
    	{
    		var distance = Vector3.Distance(transform.position, Target.transform.position);
    		var ratio = Mathf.Clamp01((distance - MinDistance) / (MaxDistance - MinDistance));
    		var inverseRatio = 1f - ratio;
    		SpriteRenderer.color = new Color(ratio * ratio, 0f, inverseRatio * inverseRatio);
    	}
    }
