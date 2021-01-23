    // make the zoom factor accessible
    float zoom = 1.5f;
    // the graphics transformation
    Matrix viewMatrix = new Matrix();
    // the reverse transformation for the mouse point
    Matrix viewMatrixRev = new Matrix();
    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            // first we reverse translate the point
            // we need an array!
            PointF[] tv = new PointF[] { e.Location };
            viewMatrixRev.TransformPoints(tv);
            // after the reversal we can use the coordinates
            float xPos = tv[0].X;
            float yPos = tv[0].Y;
            // revers translation for the point
            Matrix scaleMatrixRev = new Matrix(1f / zoom, 0, 0, 1f / zoom, 0, 0);
            // the other transformations
            Matrix scaleMatrix = new Matrix(zoom, 0, 0, zoom, 0, 0);
            Matrix translateOrigin = new Matrix(1, 0, 0, 1, xPos, yPos);
            Matrix translateBack = new Matrix(1, 0, 0, 1, -xPos, -yPos);
            // we need two different orders, not sure yet why(?)
            MatrixOrder moP = MatrixOrder.Prepend;
            MatrixOrder moA = MatrixOrder.Append;
            // graphics transfomation
            viewMatrix.Multiply(translateOrigin, moP );
            viewMatrix.Multiply(scaleMatrix, moP ); 
            viewMatrix.Multiply(translateBack, moP ); 
            // store the next point reversal:
            viewMatrixRev.Multiply(translateBack, moA); 
            viewMatrixRev.Multiply(scaleMatrixRev, moA); 
            viewMatrixRev.Multiply(translateOrigin, moA); 
        }
        else
        {
            // reset
            viewMatrix = new Matrix();
            viewMatrixRev = new Matrix();
        }
        panel1.Invalidate();
    }
