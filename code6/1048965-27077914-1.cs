    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    namespace WpfApplication1
    {
      public class Item
      {
        private readonly Rectangle shape;
        public Item( Canvas canvas )
        {
          shape = new Rectangle { Width = 50, Height = 50, Fill = Brushes.Black };
          canvas.Children.Add( shape );
          SetPosition( 0.0, 0.0 );
        }
        public void SetPosition( double x, double y )
        {
          Canvas.SetLeft( shape, x );
          Canvas.SetTop( shape, y );
        }
      }
      public partial class MainWindow : Window
      {
        private readonly IList<Item> shapes;
        private Item currentMovingShape;
        public MainWindow()
        {
          InitializeComponent();
          shapes = new List<Item>();
          InitMovingShape();
        }
        private void InitMovingShape()
        {
          currentMovingShape = new Item( canvas );
        }
        private void SetMovingShapePosition( MouseEventArgs e )
        {
          var pos = e.GetPosition( canvas );
          currentMovingShape.SetPosition( pos.X, pos.Y );
        }
        private void Canvas_MouseMove( object sender, MouseEventArgs e )
        {
          SetMovingShapePosition( e );
        }
        private void Canvas_MouseDown( object sender, MouseButtonEventArgs e )
        {
          shapes.Add( currentMovingShape );
          InitMovingShape();
          SetMovingShapePosition( e );
        }
      }
    }
