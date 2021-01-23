    public void RotateToRight()
    {           
           double cos = Math.Cos(angle);
           double sin = Math.Sin(angle);
    
           double[] rot = { cos, 0, -sin, 0,
                              0, 1,    0, 0,
                            sin, 0,  cos, 0,
                              0, 0,    0, 1};
                    
           transform.SetMatrix(DoubleArrayToIntPtr(rot));
           camera.ApplyTransform(transform);
           renderer.ResetCamera();
           renderer.GetActiveCamera();
           ForceWindowToRender();
    }
