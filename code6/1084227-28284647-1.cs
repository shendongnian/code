        /// <summary>
        /// Rotates one point around another
        /// <see href="http://stackoverflow.com/questions/13695317/rotate-a-point-around-another-point"/>
        /// </summary>
        /// <param name="pointToRotate">The point to rotate.</param>
        /// <param name="centerPoint">The centre point of rotation.</param>
        /// <param name="angleInDegrees">The rotation angle in degrees.</param>
        /// <returns>Rotated point</returns>
        private static Point RotatePoint(Point pointToRotate, Point centerPoint, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            return new Point
            {
                X =
                    (int)
                    ((cosTheta * (pointToRotate.X - centerPoint.X)) -
                    ((sinTheta * (pointToRotate.Y - centerPoint.Y)) + centerPoint.X)),
                Y =
                    (int)
                    ((sinTheta * (pointToRotate.X - centerPoint.X)) +
                    ((cosTheta * (pointToRotate.Y - centerPoint.Y)) + centerPoint.Y))
            };
        }
