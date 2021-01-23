    private Stack<Matrix4> matrix = new Stack<Matrix4>();
    public Matrix4 Peek()
    {
		return matrix.Peek();
       
    }
	
	public void Peek(Matrix4 value)
    {
		matrix.Pop();
		matrix.Push(value);
       
    }
	 		
    public Matrix4 MatrixNormal()
    {
        Matrix4 m = matrix.Peek();
            m.Invert();
            m.Transpose();
            return m;
    }
    public int Uniform { get; set; }
    public int UniformNormal { get; set; }
    private void SetUniforms()
    {
        if (Uniform == -1 || UniformNormal == -1)
            throw new Exception("Projection matrix uniform is uninitialized");
			var matrix = Peek();
        GL.UniformMatrix4(Uniform, false, ref matrix);
		var matrixNormal = MatrixNormal();
        GL.UniformMatrix4(UniformNormal, false, ref matrixNormal);            
    }
