            Texture2D[] texts =  new Texture2D[40000];
            bool bol = true;
            public void DrawModel( camera cam)
            {
               
                int i = 0;
                foreach (ModelMesh mesh in model.Meshes)
                {
                    foreach (ModelMeshPart part in mesh.MeshParts)
                    {
                        effect.Parameters["World"].SetValue(World );
                        effect.Parameters["View"].SetValue(View);
                        effect.Parameters["Projection"].SetValue(Projection);
                        effect.Parameters["TextureEnabled"].SetValue(true);
                        
                        var basicEffect = part.Effect as BasicEffect;
                        if (bol && basicEffect != null)
                        {
                            texts[i] = basicEffect.Texture;
                        }
                        
                        effect.Parameters["Texture"].SetValue(texts[i]);
                        i++;
                        part.Effect = effect;
                    }
                    mesh.Draw();
                }
                bol = false;
            }
