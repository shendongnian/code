	[ExecuteInEditMode]
	public class StretchSprite : MonoBehaviour
	{
		public tk2dCamera UserInterfaceCamera;
		private tk2dSprite _sprite;
		protected void Start()
		{
			_sprite = GetComponent<tk2dSprite>();
		}
		protected void Update()
		{
			if (_sprite)
			{
				_sprite.scale = new Vector3(UserInterfaceCamera.ScreenExtents.height / _sprite.CurrentSprite.GetUntrimmedBounds().size.y,
					UserInterfaceCamera.ScreenExtents.width / _sprite.CurrentSprite.GetUntrimmedBounds().size.x, 1.0f);
			}
		}
    }
