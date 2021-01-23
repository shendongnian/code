    private string hitobject;
    void OnCollisionEnter(UnityEngine.Collision hit)
    {
		hitobject = hit.gameObject.tag;
        if(hitobject == "Plane")
        {
			isgrounded = true;
        }
    }
