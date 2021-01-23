    public class TilePositions
    {
        //The objects in your grid
        public Transform[,] objects;
    
        //Offset from (0,0) that your grid's top-left is at.
        public Vector3 offset;
    
        //Scale of your grid
        public Vector2 scale;
    
        //Swap the objects at position one and position two in the grid
        public void Swap(Point one, Point two)
        {
            var temp = objects[one.x,one.y];
            
            objects[one.x,one.y] = objects[two.x,two.y];
            objects[two.x,two.y] = temp;
    
            objects[one.x,one.y].Position = new Vector3(one.x,one.y,0) * scale + offset;
            objects[two.x,two.y].Position = new Vector3(two.x,two.y,0) * scale + offset;
        }
    
        /// <summary>
        /// Converts a transform's vector3 position to a Point struct
        /// </summary>
        /// <param name="obj">The transform whose position is to be converted</param>
        /// <returns>System.Drawing.Point for the grid's position</returns>
        private Point PositionToPoint(Transform obj)
        {
            var position = (obj.Position - offset) / scale;
            return new Point((int)position.x, (int)position.y);
        }
    }
