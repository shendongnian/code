        protected void DrawQuad(Color color, params Vector3[] nodes)
        {
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            GL.Enable(EnableCap.PolygonOffsetFill);
            // special code when translucent
            if (color.A<255)
            {
                GL.Enable(EnableCap.Blend);
                GL.DepthMask(false);
            }
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(color);    //this is where the color with alpha is used
            for (int i=0; i<nodes.Length; i++)
            {
                GL.Vertex3(nodes[i]);
            }
            GL.End();
            // special code when translucent
            if (color.A<255)
            {
                GL.Disable(EnableCap.Blend);
                GL.DepthMask(true);
            }
        }
