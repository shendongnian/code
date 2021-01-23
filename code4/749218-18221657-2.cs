    private static bool CorrectCollisions(ref Crate c1, ref Player c2)
    {
        for (int i = 0; i < c1.model.Meshes.Count; i++)
        {
            // Check whether the bounding boxes of the two cubes intersect.
            BoundingSphere c1BoundingSphere = c1.model.Meshes[i].BoundingSphere;
            c1BoundingSphere.Center += c1.position + new Vector3(2, 0, 2);
            c1BoundingSphere.Radius = c1BoundingSphere.Radius / 1.5f;
            for (int j = 0; j < c2.model.Meshes.Count; j++)
            {
                BoundingSphere c2BoundingSphere = c2.model.Meshes[j].BoundingSphere;
                c2BoundingSphere.Center += c2.position;
                if (c1BoundingSphere.Intersects(c2BoundingSphere))
                {
                    c2.position += (c2BoundingSphere.Center - c1BoundingSphere.Center);
                }
            }
        }
        return false;
    } 
