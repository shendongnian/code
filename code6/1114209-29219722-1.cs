    IEnumerator HandleWWWRequest(string url, System.Action<WWW> onSuccess) {
		WWW www = new WWW(url);
		yield return www;
		if (string.IsNullOrEmpty(www.error)) {
			onSuccess(www);
		} else {
			Debug.LogWarning("WWW request returned an error.");
		}
	}
    ...
    if (isClass) {
        if(!connected){
            string url = "http://localhost/ws/get/clase/D1";
            // Non-blocking... success handling code is passed as a lambda
            StartCoroutine(HandleWWWRequest(url, (www) => {
                JSONObject jo = JSONObject.Parse(www.text);
                connected = true;
            }));
        }
    }
