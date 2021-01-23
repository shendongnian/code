    BoxCollider quadCollider;
    quadCollider = GameObject.Find ("green_quad").GetComponent<BoxCollider> ();
    SizeX = 0;
    SizeY = 0;
    SizeX = quadCollider.size.x;
    SizeY = quadCollider.size.y;
