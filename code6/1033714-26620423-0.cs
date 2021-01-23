        public static void Run()
        {
            int uniformLocation = GL.GetUniformLocation(shaderProgramHandle, "pvm");
            Matrix4 mat;
            GL.GetFloat(GetPName.ProjectionMatrix, out mat);
            GL.UniformMatrix4(uniformLocation, false, ref mat);
            GL.UseProgram(shaderProgramHandle);
        }
