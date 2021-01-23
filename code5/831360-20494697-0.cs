    var transform = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0))* // camera position
                             Matrix.CreateRotationZ(_rotation)* // camera rotation, default 0
                             Matrix.CreateScale(new Vector3(Zoom, Zoom, 1))* // Zoom default 1
                             Matrix.CreateTranslation(
                                 new Vector3(
                                     Device.Viewport.Width*0.5f,
                                     Device.Viewport.Height*0.5f, 0)); // Device from DeviceManager, center camera to given position
    SpriteBatch.Begin( // SpriteBatch variable
                SpriteSortMode.BackToFront, // Sprite sort mode - not related
                BlendState.NonPremultiplied, // BelndState - not related
                null,
                null,
                null,
                null,
                transformation); // set camera tranformation
