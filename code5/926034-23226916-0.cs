    void Update() {
        float y = Random.Range(-4.53f, 2.207f);
        if(x < 2000) {
            GameObject clone = (GameObject)Instantiate(obstacle, new Vector3(y, x * 6.0f, 0),Quaternion.identity);
            clone.AddComponent(typeof(DestroyMySelf));
            x++;
        }
    }
