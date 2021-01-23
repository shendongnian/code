    private void SetPerspectiveProjection (int width, int height, float FOV)
    {
    	projectionMatrix = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI * (FOV/180f), width / (float)height, 0.2f, 256.0f);
    	GL.MatrixMode(MatrixMode.Projection);
    	GL.LoadMatrix(ref projectionMatrix); // this replaces the old matrix, no need for GL.LoadIdentity()
    }
    
    private void SetOrthographicProjection ()
    {
    	projectionMatrix = Matrix4.Identity;
    	GL.MatrixMode(MatrixMode.Projection);
    	GL.LoadIdentity(); // reset matrix
    	GL.Ortho (-1f, 1f, -1f, 1f, 1000f, -1000f);
    }
    
    private void SetLookAtCamera(Vector3 position, Vector3 target, Vector3 up)
    {
    	modelViewMatrix = Matrix4.LookAt(position, target, up);
    	GL.MatrixMode(MatrixMode.Modelview);
    	GL.LoadMatrix(ref modelViewMatrix);
    }
