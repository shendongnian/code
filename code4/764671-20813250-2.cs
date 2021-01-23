    /// <summary>
    /// Resolution
    /// </summary>
    public static class Resolution
    {
        private static Vector3 ScalingFactor;
        private static int _preferredBackBufferWidth;
        private static int _preferredBackBufferHeight;
        /// <summary>
        /// The virtual screen size. Default is 1280x800. See the non-existent documentation on how this works.
        /// </summary>
        public static Vector2 VirtualScreen = new Vector2(1280, 800);
        /// <summary>
        /// The screen scale
        /// </summary>
        public static Vector2 ScreenAspectRatio = new Vector2(1, 1);
        /// <summary>
        /// The scale used for beginning the SpriteBatch.
        /// </summary>
        public static Matrix Scale;
        /// <summary>
        /// The scale result of merging VirtualScreen with WindowScreen.
        /// </summary>
        public static Vector2 ScreenScale;
        /// <summary>
        /// Updates the specified graphics device to use the configured resolution.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <exception cref="System.ArgumentNullException">device</exception>
        public static void Update(GraphicsDeviceManager device)
        {
            if (device == null) throw new ArgumentNullException("device");
            //Calculate ScalingFactor
            _preferredBackBufferWidth = device.PreferredBackBufferWidth;
            float widthScale = _preferredBackBufferWidth / VirtualScreen.X;
            _preferredBackBufferHeight = device.PreferredBackBufferHeight;
            float heightScale = _preferredBackBufferHeight / VirtualScreen.Y;
            ScreenScale = new Vector2(widthScale, heightScale);
            ScreenAspectRatio = new Vector2(widthScale / heightScale);
            ScalingFactor = new Vector3(widthScale, heightScale, 1);
            Scale = Matrix.CreateScale(ScalingFactor);
            device.ApplyChanges();
        }
        /// <summary>
        /// <para>Determines the draw scaling.</para>
        /// <para>Used to make the mouse scale correctly according to the virtual resolution,
        /// no matter the actual resolution.</para>
        /// <para>Example: 1920x1080 applied to 1280x800: new Vector2(1.5f, 1,35f)</para>
        /// </summary>
        /// <returns></returns>
        public static Vector2 DetermineDrawScaling()
        {
            var x = _preferredBackBufferWidth / VirtualScreen.X;
            var y = _preferredBackBufferHeight / VirtualScreen.Y;
            return new Vector2(x, y);
        }
    }
