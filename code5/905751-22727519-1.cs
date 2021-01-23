    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Diagnostics;
    
    namespace WpfLsysRender
    {
        class DrawingVisualElement : FrameworkElement
        {
            public DrawingVisual visual;
    
            public DrawingVisualElement() { visual = new DrawingVisual(); }
    
            protected override int VisualChildrenCount { get { return 1; } }
    
            protected override Visual GetVisualChild(int index) { return visual; }
        }
    
        class State
        {
            public double size;
    
            public double angle;
    
            public double x;
    
            public double y;
    
            public double dir;
    
            public State Clone() { return (State) this.MemberwiseClone(); }
        }
    
        public partial class MainWindow : Window
        {
            static string Rewrite(Dictionary<char, string> tbl, string str)
            {
                var sb = new StringBuilder();
    
                foreach (var elt in str)
                {
                    if (tbl.ContainsKey(elt))
                        sb.Append(tbl[elt]);
                    else
                        sb.Append(elt);
                }
                
                return sb.ToString();
            }
    
            public MainWindow()
            {
                InitializeComponent();
    
                Width = 800;
                Height = 800;
    
                var bitmap = BitmapFactory.New(800, 800);
    
                Content = new Image() { Source = bitmap };
    
                var states = new Stack<State>();
    
                var str = "L";
    
                {
                    var tbl = new Dictionary<char, string>();
    
                    tbl.Add('L', "|-S!L!Y");
                    tbl.Add('S', "[F[FF-YS]F)G]+");
                    tbl.Add('Y', "--[F-)<F-FG]-");
                    tbl.Add('G', "FGF[Y+>F]+Y");
    
                    for (var i = 0; i < 12; i++) str = Rewrite(tbl, str);
                }
    
                var sizeGrowth = -1.359672;
                var angleGrowth = -0.138235;
    
                State state;
    
                var lines = new List<Point>();
    
                var pen = new Pen(new SolidColorBrush(Colors.Black), 0.25);
    
                var geometryGroup = new GeometryGroup();
    
                Action buildLines = () =>
                    {
                        lines.Clear();
    
                        state = new State()
                        {
                            x = 400,
                            y = 400,
                            dir = 0,
                            size = 14.11,
                            angle = -3963.7485
                        };
    
                        foreach (var elt in str)
                        {
                            if (elt == 'F')
                            {
                                var new_x = state.x + state.size * Math.Cos(state.dir * Math.PI / 180.0);
                                var new_y = state.y + state.size * Math.Sin(state.dir * Math.PI / 180.0);
    
                                lines.Add(new Point(state.x, state.y));
                                lines.Add(new Point(new_x, new_y));
    
                                state.x = new_x;
                                state.y = new_y;
                            }
                            else if (elt == '+') state.dir += state.angle;
    
                            else if (elt == '-') state.dir -= state.angle;
    
                            else if (elt == '>') state.size *= (1.0 - sizeGrowth);
    
                            else if (elt == '<') state.size *= (1.0 + sizeGrowth);
    
                            else if (elt == ')') state.angle *= (1 + angleGrowth);
    
                            else if (elt == '(') state.angle *= (1 - angleGrowth);
    
                            else if (elt == '[') states.Push(state.Clone());
    
                            else if (elt == ']') state = states.Pop();
    
                            else if (elt == '!') state.angle *= -1.0;
    
                            else if (elt == '|') state.dir += 180.0;
                        }
                    };
    
                Action updateBitmap = () =>
                    {
                        using (bitmap.GetBitmapContext())
                        {
                            bitmap.Clear();
    
                            for (var i = 0; i < lines.Count; i += 2)
                            {
                                var a = lines[i];
                                var b = lines[i+1];
    
                                bitmap.DrawLine(
                                    (int) a.X, (int) a.Y, (int) b.X, (int) b.Y, 
                                    Colors.Black);
                            }
                        }
                    };
                
                MouseDown += (s, e) =>
                    {
                        angleGrowth += 0.001;
                        Console.WriteLine("angleGrowth: {0}", angleGrowth);
    
                        var sw = Stopwatch.StartNew();
    
                        buildLines();
                        updateBitmap();
    
                        sw.Stop();
                        
                        Console.WriteLine(sw.Elapsed);
                    };
    
                buildLines();
    
                updateBitmap();
            }
        }
    }
