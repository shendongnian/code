        public void Render()
        {
            if (Shading==ShadingModel.Smooth)
            {
                GL.Enable(EnableCap.ColorMaterial);
                GL.ColorMaterial(MaterialFace.FrontAndBack, ColorMaterialParameter.AmbientAndDiffuse);
                GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular, SpecularColor);
                GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Emission, EmissionColor);
                GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Shininess, Shinyness);
                GL.Enable(EnableCap.Lighting);
            }
            else
            {
                GL.Disable(EnableCap.ColorMaterial);
                GL.Disable(EnableCap.Lighting);
            }
            GL.ShadeModel(Shading);
            GL.Translate(Position);
            GL.Scale(Scale, Scale, Scale);
            Draw(); // Draws triangles and quads to make up a shape
        }
