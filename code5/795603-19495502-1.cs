    if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W)){
        //cameraPosition += new Vector3(0.0f, 50.0f, +100);
    }
    if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S)){
        //cameraPosition -= new Vector3(0.0f, 50.0f, +100);
    }
    if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D)){
        //cameraPosition += new Vector3(1, 0, 0);
        angleRightLeft += 0.05f;
    }
    if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A)){
        //cameraPosition += new Vector3(-1, 0, 0);
        angleRightLeft -= 0.05f;
    }
