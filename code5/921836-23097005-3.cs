        protected void DrawLineLoop(Color color, params Vector3[] nodes)
        {
            GL.Disable(EnableCap.PolygonOffsetFill);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            if (color.A<255)
            {
                GL.Enable(EnableCap.Blend);
                GL.DepthMask(false);
            }
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color4(color);
            for (int i=0; i<nodes.Length; i++)
            {
                GL.Vertex3(nodes[i]);
            }
            GL.End();
            if (color.A<255)
            {
                GL.Disable(EnableCap.Blend);
                GL.DepthMask(true);
            }
        }
