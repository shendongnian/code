    public void Render(Camera cam)
    {
        //...
        //push the cube to the origin
        bEffect.World *= Matrix.CreateTranslation(-50, -50, 50); 
        //perform the rotation
        bEffect.World *= cam.rotX;
        bEffect.World *= cam.rotY;
        bEffect.World *= cam.rotZ;
        //undo the translation
        bEffect.World *= Matrix.CreateTranslation(50, 50, -50);
        //...
