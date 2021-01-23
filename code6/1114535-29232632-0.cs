    //Predefined positions where objects to place
	public Transform[] Position;
	//The objects that will will be swapped in coroutines
	public Transform[] ObjectsToMove;
	private int ObjectIndex = 0;
	private bool startupdate = true;
	void Update () {
		if(startupdate)
		   StartCoroutine(SwitchBlocks());
	}
	IEnumerator SwitchBlocks() {
		startupdate = false;
		int tempIndex = ObjectIndex;
		for(int i = 0; i < ObjectsToMove.Length; i++) {
			tempIndex = ObjectIndex + i;
			if(tempIndex > ObjectsToMove.Length - 1)
				tempIndex -= ObjectsToMove.Length;
			ObjectsToMove[i].position = Position[tempIndex].position;
		}
		ObjectIndex++;
		if(ObjectIndex > ObjectsToMove.Length - 1) {
			ObjectIndex = 0;
		}
		yield return new WaitForSeconds(2.0f);
		startupdate = true;
		yield return null;
	}
