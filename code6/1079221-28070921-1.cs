            Point4D p1 = new Point4D(1, -0.75, -0.3, 1);
            Point4D p2 = new Point4D(1, 0.75, -0.3, 1);
            Point4D p3 = new Point4D(1, 0.75, 0.3, 1);
            Point4D p4 = new Point4D(1, -0.75, 0.3, 1);
            Vector3D xAxis = new Vector3D(p2.X - p1.X, p2.Y - p1.Y, p2.Z - p1.Z);
            Vector3D hAxis = new Vector3D(p3.X - p1.X, p3.Y - p1.Y, p3.Z - p1.Z);
            Vector3D zAxis = Vector3D.CrossProduct(xAxis, hAxis);
            Vector3D yAxis = Vector3D.CrossProduct(zAxis, xAxis);
            xAxis.Normalize();
            yAxis.Normalize();
            zAxis.Normalize();
            Matrix3D trans = new Matrix3D(xAxis.X, xAxis.Y, xAxis.Z, 0,
                                          yAxis.X, yAxis.Y, yAxis.Z, 0,
                                          zAxis.X, zAxis.Y, zAxis.Z, 0,
                                          p1.X, p1.Y, p1.Z, 1);    // **** changed this
            trans.Invert();    // **** added this
            Point4D n1 = p1 * trans;
            Point4D n2 = p2 * trans;
            Point4D n3 = p3 * trans;
            Point4D n4 = p4 * trans;
