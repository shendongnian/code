        public void RenderOnView(GLControl control)
        {
            control.MakeCurrent();
            var camera=views[control];
            GL.Clear(ClearBufferMask.ColorBufferBit|ClearBufferMask.DepthBufferBit);
            GL.Disable(EnableCap.CullFace);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
            camera.LookThrough();
            if (EnableLights)
            {
                GL.LightModel(LightModelParameter.LightModelAmbient, new[] { 0.2f, 0.2f, 0.2f, 1f });
                GL.LightModel(LightModelParameter.LightModelLocalViewer, 1);
                GL.Enable(EnableCap.Lighting);
                foreach (var light in lights)
                {
                    light.Render();
                }
            }
            else
            {
                GL.Disable(EnableCap.Lighting);
                GL.ShadeModel(ShadingModel.Flat);
            }
            GL.Enable(EnableCap.LineSmooth); // This is Optional 
            GL.Enable(EnableCap.Normalize);  // These is critical to have
            GL.Enable(EnableCap.RescaleNormal);
            for (int i=0; i<objects.Count; i++)
            {
                GL.PushMatrix();
                objects[i].Render();
                GL.PopMatrix();
            }
            control.SwapBuffers();
        }
