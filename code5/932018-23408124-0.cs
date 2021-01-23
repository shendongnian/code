	int counting = 5;
	bool invokedReset = false;
	void Update(){
		if(Input.GetKeyDown(KeyCode.O) && counting > 0){
			counting --;
		}
		else if(counting <= 0 && !invokedReset)
		{
			Invoke ("ResetCounting",3);
			invokedReset = true;
		}
		print (counting);
	}
	void ResetCounting ()
	{
		counting = 5;
		invokedReset = false;
	}
