    IEnumerator UserLogin(string username,string pass){
		Task task = ParseUser.LogInAsync(username, pass);
		while (!task.IsCompleted) yield return null;
		if (task.IsFaulted || task.IsCanceled)
		{
			Debug.Log("login is false");   
		}
		else
		{
			Debug.Log ("User exists");
            // do your log in action here
			StartCoroutine(DoClose("loggedin"));
		}
	}
