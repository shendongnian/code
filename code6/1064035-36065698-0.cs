    using System.Windows; 
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;
    using System.Windows.Controls.Primitives;
    using System.Windows.Controls;
    public class InteractivePoint : UIElement3D   
    {
        public InteractivePoint(Point3D center, Material material, double sphereSize = 0.07)
        {
           MeshBuilder builder  = new MeshBuilder();
           
           builder.AddSphere( center, sphereSize , 4, 4 );
           GeometryModel3D model = new GeometryModel3D( builder.ToMesh(), material );
            Visual3DModel = model;
        }
        protected override void OnMouseEnter( MouseEventArgs event )
        {
            base.OnMouseEnter( event );
            
            GeometryModel3D point = Visual3DModel as GeometryModel3D;
                
            point.Material = Materials.Red; //change mat to red on mouse enter
            Event.Handled = true;
        }
        protected override void OnMouseLeave( MouseEventArgs event )
        {
            base.OnMouseEnter( event );
            
            GeometryModel3D point = Visual3DModel as GeometryModel3D;
              
            point.Material = Materials.Blue; //change mat to blue on mouse leave
            Event.Handled = true;
        }
    }
