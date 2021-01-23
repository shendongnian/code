    class GameBody
    {
        public Body body;
        public Vector2 position;
        public int width;
        public int height;
        public GameBody(int width, int height, int x, int y, BodyType bodyType)
        {
            this.width = width;
            this.height = height;
            body = BodyFactory.CreateRectangle(Game1.world, ConvertUnits.ToSimUnits((float)width), ConvertUnits.ToSimUnits((float)height), 1f);
            body.BodyType = bodyType;
            body.FixedRotation = false;
            body.SleepingAllowed = true;
            body.LinearDamping = 1f;
            body.AngularDamping = 2f;
            setPosition(x, y);
            body.UserData = this;
            body.OnCollision += gameBody_OnCollision;
        }
        public void setPosition(float x, float y)
        {
            position.X = x;
            position.Y = y;
            body.SetTransform(new Vector2(ConvertUnits.ToSimUnits(x), ConvertUnits.ToSimUnits(y)), 0);
        }
        bool gameBody_OnCollision(Fixture me, Fixture him, Contact contact)
        {
            float Width = (him.Body.UserData as GameBody).width;
            float Height = (him.Body.UserData as GameBody).height;
            return true;
        }
    }
