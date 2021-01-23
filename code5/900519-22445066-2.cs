    public class Matrix
    {
        private Stack<Matrix4> matrix = new Stack<Matrix4>();
    	Matrix4 peek = null; 
        public Matrix4 Peek()
        {
    		peek = matrix.Peek();
    		return peek;
           
        }
    	
    	public void Peek(Matrix4 value)
        {
    		matrix.Pop();
    		matrix.Push(value);
           
        }
    	private Matrix normalMatrix = null;
        public Matrix4 MatrixNormal()
        {
            Matrix4 m = matrix.Peek();
                m.Invert();
                m.Transpose();
    			normalMatrix = m;
                return normalMatrix;
        }
        public int Uniform { get; set; }
        public int UniformNormal { get; set; }
    
         private void SetUniforms()
   
     {
            if (Uniform == -1 || UniformNormal == -1)
                throw new Exception("Projection matrix uniform is uninitialized");
    		Peek();
    		MatrixNormal();
            GL.UniformMatrix4(Uniform, false, ref peek);
    		
            GL.UniformMatrix4(UniformNormal, false, ref normalMatrix);            
        }
