    void Update () {
        //select ();
        int i = 0;
        while (i < Input.touchCount) {
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
                Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                Vector2 touchPos = new Vector2(wp.x, wp.y);
                if (collider2D == Physics2D.OverlapPoint(touchPos))
                {
                    Material newMat = Resources.Load("New Material", typeof(Material)) as Material;
                    gameObject.renderer.material = newMat;
                    PlayersManager.objPlayerList.Add(PlayersManager.setPlayerObject("Bear"));
                    countausplayer.countteam++;
                }
            }
        }
    }
