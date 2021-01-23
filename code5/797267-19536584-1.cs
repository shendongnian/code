    class Camera 
    { // up in here normal needed vars
    public Vector3 cameraPosition; 
    public float moveSpeed, rotateSpeed; 
    
    public bool playing = true; 
    
    public GraphicsDevice device; 
    
    public Matrix view, projection; 
    
    Matrix rotation; 
    
    float yaw = 0; 
    float pitch = 0; 
    
    int oldX, oldY; 
    
    public Camera(Vector3 cameraPosition, float moveSpeed, float rotateSpeed, float filedOfView, GraphicsDevice device, float PerspectiveFieldOfView) 
    { 
    this.cameraPosition = cameraPosition; 
    this.moveSpeed = moveSpeed; 
    this.rotateSpeed = rotateSpeed; 
    this.device = device; 
    view = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up); 
    projection =  Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(PerspectiveFieldOfView), device.Viewport.AspectRatio, 0.1f, filedOfView); 
    
    ResetMouseCursor(); 
    } 
    
    public void Update() 
    { 
    KeyboardState kState = Keyboard.GetState(); // make is able to use your keys
    Vector3 v = new Vector3(0, 0, -50) * moveSpeed; // let you permanent walk 
    move(v);                                        // isnt essential could be deleted if you wont that
    } 
    
    if (kState.IsKeyDown(Keys.W)) 
    { 
    Vector3 v = new Vector3(0, 0, -100) * moveSpeed; 
    move(v); 
    } 
    
    if (kState.IsKeyDown(Keys.S)) 
    { 
    Vector3 v = new Vector3(0, 0, 50) * moveSpeed; 
     move(v); 
    } 
    
    if (kState.IsKeyDown(Keys.A)) 
    { 
    Vector3 v = new Vector3(-50, 0, 0) * moveSpeed; 
     move(v); 
     projection = Matrix. 
     } 
    
    if (kState.IsKeyDown(Keys.D)) 
    { 
    Vector3 v = new Vector3(50, 0, 0) * moveSpeed; 
    move(v); 
    } 
    
    pitch = MathHelper.Clamp(pitch, -1.5f, 1.5f); 
    MouseState mState = Mouse.GetState(); 
    
    int dx = mState.X - oldX;      /* is for turning you objekt / camera
    yaw -= rotateSpeed * dx;        *
                                    *
    int dy = mState.Y - oldY;       *
    pitch -= rotateSpeed * dy;      */
    ResetMouseCursor();          // this makes your mouse "dancing" in the middle
    
    UpdateMatrices(); 
    } 
    
    private void ResetMouseCursor() // mouse settings for the camera
    { 
    int centerX = device.Viewport.Width / 2; 
    int centerY = device.Viewport.Height / 2; 
    Mouse.SetPosition(centerX, centerY); 
    oldX = centerX; 
    oldY = centerY; 
    } 
    private void UpdateMatrices() //standart camera things
    { 
    rotation = Matrix.CreateRotationY(yaw) * Matrix.CreateRotationX(pitch); 
    Vector3 transformedReference = Vector3.Transform(new Vector3(0, 0, -1), rotation); 
    Vector3 lookAt = cameraPosition + transformedReference; 
    
    view = Matrix.CreateLookAt(cameraPosition, lookAt, Vector3.Up); 
    } 
    public void move(Vector3 v) // is the self programmed method to let you move
    { 
    Matrix yRotation = Matrix.CreateRotationY(yaw); 
    v = Vector3.Transform(v, yRotation); 
    
    cameraPosition += v; 
    } 
    
    } 
