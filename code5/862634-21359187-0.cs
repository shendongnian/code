        public float Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                position = Rotate(MathHelper.ToRadians(angle), Distance, SunPosition + Origin);
            }
        }
        public static Vector2 Rotate(float angle, float distance, Vector2 centrer)
        {
            return new Vector2((float)(distance * Math.Cos(angle)), (float)(distance * Math.Sin(angle))) + center;
        }
