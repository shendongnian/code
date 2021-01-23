        public Point3D CalculateCentroid(List<Point3D> verticies)
        {
            var s = new Vector3D();
            var areaTotal = 0.0;
            var p1 = verticies[0];
            var p2 = verticies[1];
            for (var i = 2; i < verticies.Count; i++)
            {
                var p3 = verticies[i];
                var edge1 = p3 - p1;
                var edge2 = p3 - p2;
                var crossProduct = Vector3D.CrossProduct(edge1, edge2);
                var area = crossProduct.Length/2;
                s.X += area * (p1.X + p2.X + p3.X)/3;
                s.Y += area * (p1.Y + p2.Y + p3.Y)/3;
                s.Z += area * (p1.Z + p2.Z + p3.Z)/3;
                areaTotal += area;
                p2 = p3;
            }
            var point = new Point3D
            {
                X = s.X/areaTotal,
                Y = s.Y/areaTotal,
                Z = s.Z/areaTotal
            };
            return point;
        }
