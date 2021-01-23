    using System;
    using System.Drawing;
    using System.IO;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    namespace OpenTKTutorial1
    {
        public class Game
            : GameWindow
        {
            int pgmID;
            int vsID;
            int fsID;
            int attribute_vcol;
            int attribute_vpos;
            int uniform_mview;
            int vbo_position;
            int vbo_color;
            int vbo_mview;
            Vector3[] vertdata;
            Vector3[] coldata;
            Matrix4[] mviewdata;
            public Game()
            {
                // better use the events instead of overriding the inherited methods
                // at least thats what the documentation on Update- and RenderFrame says
                Load += OnLoad;
                UpdateFrame += OnUpdateFrame;
                RenderFrame += OnRenderFrame;
            }
            void InitProgram()
            {
                pgmID = GL.CreateProgram();
                LoadShader("vs.glsl", ShaderType.VertexShader, pgmID, out vsID);
                LoadShader("fs.glsl", ShaderType.FragmentShader, pgmID, out fsID);
                GL.LinkProgram(pgmID);
                Console.WriteLine(GL.GetProgramInfoLog(pgmID));
                attribute_vpos = GL.GetAttribLocation(pgmID, "vPosition");
                attribute_vcol = GL.GetAttribLocation(pgmID, "vColor");
                uniform_mview = GL.GetUniformLocation(pgmID, "modelview");
                if (attribute_vpos == -1 || attribute_vcol == -1 || uniform_mview == -1)
                {
                    Console.WriteLine("Error binding attributes");
                }
                GL.GenBuffers(1, out vbo_position);
                GL.GenBuffers(1, out vbo_color);
                // what is this buffer for?
                //GL.GenBuffers(1, out vbo_mview);
            }
            void LoadShader(String filename, ShaderType type, int program, out int address)
            {
                address = GL.CreateShader(type);
                using (StreamReader sr = new StreamReader(filename))
                {
                    GL.ShaderSource(address, sr.ReadToEnd());
                }
                GL.CompileShader(address);
                GL.AttachShader(program, address);
                Console.WriteLine(GL.GetShaderInfoLog(address));
            }
            protected void OnLoad(object sender, EventArgs eventArgs)
            {
                InitProgram();
                vertdata = new Vector3[]{
                    new Vector3(-0.8f, -0.8f, 0f),
                    new Vector3(0.8f, -0.8f, 0f),
                    new Vector3(0f, 0.8f, 0f)};
                coldata = new Vector3[]{
                    new Vector3(1f, 0f, 0f),
                    new Vector3(0f, 0f, 1f),
                    new Vector3(0f, 1f, 0f)};
                mviewdata = new Matrix4[]{
                    Matrix4.Identity};
                Title = "Title";
                GL.ClearColor(Color.CornflowerBlue);
                GL.PointSize(5f);
            }
            protected void OnRenderFrame(object sender, FrameEventArgs frameEventArgs)
            {
                // if you only have one viewport you can safely move this to the OnResize event
                GL.Viewport(0, 0, Width, Height);
                // if the state never changes move it to OnLoad
                GL.Enable(EnableCap.DepthTest);
                
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                GL.EnableVertexAttribArray(attribute_vpos);
                GL.EnableVertexAttribArray(attribute_vcol);
                // always make sure the program is enabled ..
                GL.UseProgram(pgmID);
                // .. before you set any uniforms 
                GL.UniformMatrix4(uniform_mview, false, ref mviewdata[0]);
                // .. or draw anything
                GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
                GL.DisableVertexAttribArray(attribute_vpos);
                GL.DisableVertexAttribArray(attribute_vcol);
                // do not call glFlush unless you have a very good reason to
                // it can result in significant slow downs
                //GL.Flush();
                SwapBuffers();
            }
            protected void OnUpdateFrame(object sender, FrameEventArgs frameEventArgs)
            {
                // your vertex and color data never changes, thus everything you do here
                // could be moved to OnLoad instead of having it repeated all the time
                GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_position);
                GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertdata.Length * Vector3.SizeInBytes), vertdata, BufferUsageHint.StaticDraw);
                GL.VertexAttribPointer(attribute_vpos, 3, VertexAttribPointerType.Float, false, 0, 0);
                GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_color);
                GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(coldata.Length * Vector3.SizeInBytes), coldata, BufferUsageHint.StaticDraw);
                GL.VertexAttribPointer(attribute_vcol, 3, VertexAttribPointerType.Float, true, 0, 0);
                GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            }
        }
    }
