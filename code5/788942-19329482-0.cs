    private Vector3 previewMove(Vector3 amount)
    {
        // Create a rotate matrix
        Matrix rotate = Matrix.CreateRotationY(CameraRotation.Y);
        // Create a movement vector
        Vector3 movement = new Vector3(amount.X, amount.Y, amount.Z);
        movement = Vector3.Transform(movement, rotate);
        // Return the value of camera position + movement vector
        return CameraPosition + new Vector3(
            Collision.CheckCollision(CameraPosition + new Vector3(movement.X, 0, 0)) ? 0 : movement.X,
            Collision.CheckCollision(CameraPosition + new Vector3(0, movement.Y, 0)) ? 0 : movement.Y,
            Collision.CheckCollision(CameraPosition + new Vector3(0, 0, movement.Z)) ? 0 : movement.Z);
    }
