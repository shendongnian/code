    [CustomEditor(typeof(B))]
    public class TestEditor : Editor {
	// your class
    B b;
	// holder enum to check changes
	MyEnum mEnumHolder;
	void OnEnable () {
		b = target as B;
        // set starting enum value
		mEnumHolder = b.myEnum;
	}
	
	// Update is called once per frame
	public override void OnInspectorGUI (){
		// draw gui
		b.myEnum = (MyEnum)EditorGUILayout.EnumPopup("My enum",b.myEnum);
		// check if gui changed
		if(GUI.changed)
		{
			// check if enum field changed
			if(b.myEnum != mEnumHolder)
			{
				// TODO  do specific action here, maybe with a switch loop
				//b.gameObject.AddComponent<Rigidbody>();
				// set new holder
				mEnumHolder = b.myEnum;
			}
		}
	}
