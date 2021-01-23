    //This is now a override of the virtual function defined in Circle
    public override void GetObjectData(SerializationInfo info, StreamingContext context)     
    {
        base.GetObjectData(info, context); //Get the base class data
        info.AddValue("brace", brace, typeof(Brace));
        info.AddValue("radius", radius, typeof(double));
        info.AddValue("centerPoint", centerPoint, typeof(Vertex));
    }
    protected BraceHole(SerializationInfo info, StreamingContext context) 
        : base(info, context) //Deserialize the base class data.
    {
       // The commented code would likely now go in the base class's protected constructor.
       //VdProControl.VdProControl vectorDraw = (VdProControl.VdProControl)context.Context;
       //VDrawI5.vdEntities entities = vectorDraw.ActiveDocument.Entities;
       try {
            brace = (Brace)info.GetValue("brace", typeof(Brace));
            radius = (double)info.GetValue("radius", typeof(double));
            centerPoint = (Vertex)info.GetValue("centerPoint", typeof(Vertex));
        }
       catch
       {
           //This empty try-catch is a bad idea, if something goes wrong you should 
           //at minimum log it some how. It would be better to get rid of it and let 
           //the caller catch the exception.
       } 
    }
