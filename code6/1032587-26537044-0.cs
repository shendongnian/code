    void OnCollisionEnter (Collision other) {
        if (other.gameObject.tag == "Player") {
            isPlayerOn = true;
        }
    }
