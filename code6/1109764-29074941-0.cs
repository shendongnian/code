    using UnityEngine;
    using System.Collections;
    public class characterLogic : MonoBehaviour {
	[SerializeField]
	private Animator animator;
	[SerializeField]
	private FollowCamera gamecam;
	[SerializeField]
	private float directionSpeed = 1.5f;
	[SerializeField]
	private float directionDampTime = 0.25f;
	[SerializeField]
	private float rotationDegreePerSecond = 120f;
	[SerializeField]
	private float speedDampTime = 0.05f;
	[SerializeField]
	private float fovDampTime = 3f;
	private float horizontal = 0.0f;
	private float vertical = 0.0f;
	private float speed = 0.0f;
	private float direction = 0.0f;
	private float charAngle = 0f;
	private const float SPRINT_SPEED = 2.0f;
	private const float SPRINT_FOV = 75.0f;
	private const float NORMAL_FOV = 60.0f;
	private const float WALK_SPEED = 0.1f;
	private AnimatorStateInfo stateInfo;
	private AnimatorTransitionInfo transInfo;
	private int m_LocomotionId = 0;
	private int m_LocomotionPivotLId = 0;
	private int m_LocomotionPivotRId = 0;
	private int m_LocomotionPivotLTransId = 0;	
	private int m_LocomotionPivotRTransId = 0;	
	public Animator Animator
	{
		get
		{
			return this.animator;
		}
	}
	
	public float Speed
	{
		get
		{
			return this.speed;
		}
	}
	
	public float LocomotionThreshold { get { return 0.2f; } }
	// Use this for initialization
	void Start () {
	
		animator = GetComponent<Animator>();
		if(animator.layerCount >= 2)
		{
			animator.SetLayerWeight(1, 1);
		}	
		m_LocomotionId = Animator.StringToHash("Base Layer.Locomotion");
		m_LocomotionPivotLId = Animator.StringToHash("Base Layer.LocomotionPivotL");
		m_LocomotionPivotRId = Animator.StringToHash("Base Layer.LocomotionPivotR");
		m_LocomotionPivotLTransId = Animator.StringToHash("Base Layer.Locomotion -> Base Layer.LocomotionPivotL");
		m_LocomotionPivotRTransId = Animator.StringToHash("Base Layer.Locomotion -> Base Layer.LocomotionPivotR");
	}
	public void keysToWorldSpace (Transform root, Transform camera, ref float directionOut, ref float speedOut, ref float angleOut, bool isPivoting){
		Vector3 rootDirection = root.forward;
		Vector3 keyDirection = new Vector3 (horizontal, 0, vertical);
		speedOut = keyDirection.sqrMagnitude;
		//get camera rotation
		Vector3 cameraDirection = camera.forward;
		cameraDirection.y = 0.0f;
		Quaternion referentialShift = Quaternion.FromToRotation(Vector3.forward, Vector3.Normalize(cameraDirection));
		//convert key input to world space coordinates
		Vector3 moveDirection = referentialShift * keyDirection;
		Vector3 axisSign = Vector3.Cross (moveDirection, rootDirection);
		Debug.DrawRay (new Vector3(root.position.x, root.position.y + 2f, root.position.z), moveDirection, Color.green);
		Debug.DrawRay (new Vector3(root.position.x, root.position.y + 2f, root.position.z), axisSign, Color.red);
		Debug.DrawRay (new Vector3(root.position.x, root.position.y + 2f, root.position.z), rootDirection, Color.magenta);
		Debug.DrawRay (new Vector3(root.position.x, root.position.y + 2f, root.position.z), keyDirection, Color.blue);
		float angleRootToMove = Vector3.Angle(rootDirection, moveDirection) * (axisSign.y >= 0 ? -1f : 1f);
		if (!isPivoting)
		{
			angleOut = angleRootToMove;
		}
		angleRootToMove /= 180f;
		directionOut = angleRootToMove * directionSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (animator) {
			stateInfo = animator.GetCurrentAnimatorStateInfo(0);
			transInfo = animator.GetAnimatorTransitionInfo(0);
			horizontal = Input.GetAxis("Horizontal");
			vertical = Input.GetAxis("Vertical");
			charAngle = 0f;
			direction = 0f;
			float charSpeed = 0f;
			
			keysToWorldSpace (this.transform, gamecam.transform, ref direction, ref charSpeed, ref charAngle, isInPivot());
			if (Input.GetButton("Sprint"))
			{
				speed = Mathf.Lerp(speed, SPRINT_SPEED, Time.deltaTime);
				gamecam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(gamecam.GetComponent<Camera>().fieldOfView, SPRINT_FOV, fovDampTime * Time.deltaTime);
			}
			else
			{
				speed = charSpeed;
				gamecam.GetComponent<Camera>().fieldOfView = Mathf.Lerp(gamecam.GetComponent<Camera>().fieldOfView, NORMAL_FOV, fovDampTime * Time.deltaTime);		
			}
			if (Input.GetButton("Walk"))
			{
				speed = Mathf.Lerp(speed, WALK_SPEED, Time.deltaTime);
			}
			else
			{
				speed = charSpeed;		
			}
			animator.SetFloat("Speed", speed, speedDampTime, Time.deltaTime);
			animator.SetFloat("Direction", direction, directionDampTime, Time.deltaTime);
			if(speed > LocomotionThreshold){
				if(!isInPivot()){
					Animator.SetFloat("Angle", charAngle);
				}
			}
			if(speed < LocomotionThreshold && Mathf.Abs(horizontal) < 0.05f){
				animator.SetFloat("Direction", 0f);
				animator.SetFloat("Speed", speed, speedDampTime, Time.deltaTime);
			
			}
			Debug.Log(Speed);
			Debug.Log(charAngle);
		}
	}
	void FixedUpdate() {
		if (IsInLocomotion () && ((direction >= 0 && horizontal >= 0) || (direction < 0 && horizontal < 0))) {
			Vector3 rotationAmount = Vector3.Lerp(Vector3.zero, new Vector3(0f, rotationDegreePerSecond * (horizontal < 0f ? -1f : 1f), 0f), Mathf.Abs(horizontal));
			Quaternion deltaRotation = Quaternion.Euler(rotationAmount * Time.deltaTime);
			this.transform.rotation = (this.transform.rotation * deltaRotation);
		}
	}
	public bool isInPivot(){
		return stateInfo.fullPathHash == m_LocomotionPivotLId || 
				stateInfo.fullPathHash == m_LocomotionPivotRId || 
				transInfo.nameHash == m_LocomotionPivotLTransId || 
				transInfo.nameHash == m_LocomotionPivotRTransId;
	}
	public bool IsInLocomotion(){
		return stateInfo.fullPathHash == m_LocomotionId;
	}
