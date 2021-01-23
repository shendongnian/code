    private void rotate(double angle, int axis) {
        vtkTransform t = new vtkTransform();
        bw.GetTransform(t);
        switch(axis) {
            case X:
                t.RotateX(-angle); 
                break;
            case Y:
                t.RotateY(-angle);
                break;
            case Z:
                t.RotateZ(-angle);
                break;
        }
        
        ren.GetActiveCamera().ApplyTransform(t);
    }
