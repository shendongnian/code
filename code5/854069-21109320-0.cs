    public class MyGL
    {
        private TypeHere GL = new TypeHere();
    
        public void ClearColor(Color color)
        {
            GL.ClearColor(color);
            CheckError();
        }
    
        private void CheckError()
        {
            ErrorCode errorCode = GL.GetError();
    
            if (errorCode != ErrorCode.NoError)
                Console.WriteLine("Error!");
        }
    }
