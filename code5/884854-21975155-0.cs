        Model carModel;
            Matrix carWorldMatrix;
            
            ModelBone fr_wheel;
            ModelBone fl_wheel;
            ModelBone bl_wheel;
            ModelBone br_wheel;
            //Matrices for storing the initial transform of each wheel 
            Matrix fr_transform;
            Matrix fl_transform;
            Matrix br_transform;
            Matrix bl_transform;
            
            Matrix[] transforms;
            
            float wheelRotation;
            float wheelSteerAngle;
            float carRotation;
        
    public void Load(ContentManager content)
    {
          carModel = content.Load<Model>("car");
        
          fr_wheel = carModel.Bones["fr_tire"];
          fl_wheel = carModel.Bones["fl_tire"];
          bl_wheel = carModel.Bones["bl_tire"];
          br_wheel = carModel.Bones["br_tire"];
        
          fr_transform = fr_wheel.Transform;
          fl_transform = fl_wheel.Transform;
          br_transform = br_wheel.Transform;
          bl_transform = bl_wheel.Transform;
        
          transforms = new Matrix[carModel.Bones.Count];
    }
    
    public void Update(GameTime gameTime)
    {
         carModel.Root.Transform = carWorldMatrix;
    
         Matrix tireRotation = Matrix.CreateRotationX(wheelRotation) *
                               Matrix.CreateRotationY(wheelSteerAngle);
    
         fr_wheel.Transform = tireRotation * fr_transform;//this will apply the rotation to the     front right wheel
    
    }
    
    public void Draw(ref Camera camera)
    {
         carModel.CopyAbsoluteBoneTransformsTo(transforms);
    
         foreach (ModelMesh mesh in carModel.Meshes)
         {
             foreach (BasicEffect effect in mesh.Effects)
             {
                 effect.EnableDefaultLighting();
                 effect.World = transforms[mesh.ParentBone.Index];
                 effect.View = camera.viewMatrix;
                 effect.Projection = camera.projectionMatrix;
             }
             mesh.Draw()
         }
    }
