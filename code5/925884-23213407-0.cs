    for(int x = 0; x < 5; x++) {
       for(int y = 0; y < 5; y++) {
            GameObject go = Resources.Load("ItemPrefab") as GameObject;
            go = Instantiate(go) as GameObject;
            go.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)] as Sprite;
            float fx = -2 + 1f * x;
            float fy = -2 + 1f * y;
            go.transform.position = new Vector3(fx, fy, 0);
        }
    }
