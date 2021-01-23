    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Diagnostics;
    
    using System.Windows.Media.Imaging;
    
    // https://stackoverflow.com/q/22599806/519568
    
    namespace WpfLsysRender
    {
    
        class UpdatableUIElement : UIElement {        
            DrawingGroup backingStore = new DrawingGroup();
            public UpdatableUIElement() {
                              
            }
    
            protected override void OnRender(DrawingContext drawingContext) {
                base.OnRender(drawingContext);                    
                drawingContext.DrawDrawing(backingStore);            
            }
            public void Redraw(Action<DrawingContext> fn) {
                var vis = backingStore.Open();            
                fn(vis);
                vis.Close();
            }
        }    
    
        class State
        {
            public double size;
    
            public double angle;
    
            public double x;
    
            public double y;
    
            public double dir;
    
            public State Clone() { return (State)this.MemberwiseClone(); }
        }
    
        public partial class MainWindow : Window
        {
            static string Rewrite(Dictionary<char, string> tbl, string str) {
                var sb = new StringBuilder();
    
                foreach (var elt in str) {
                    if (tbl.ContainsKey(elt))
                        sb.Append(tbl[elt]);
                    else
                        sb.Append(elt);
                }
    
                return sb.ToString();
            }
    
            public MainWindow() {
                // InitializeComponent();
    
                Width = 800;
                Height = 800;
    
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
               
                var lsystem_view = new UpdatableUIElement();
                Content = lsystem_view;
                
    
                var sizeGrowth = -1.359672;
                var angleGrowth = -0.138235;
    
                State state;
    
                var pen = new Pen(new SolidColorBrush(Colors.Black), 0.25);
    
                var geometry = new StreamGeometry();
    
                Action buildGeometry = () => {
                    state = new State() {
                        x = 0,
                        y = 0,
                        dir = 0,
                        size = 14.11,
                        angle = -3963.7485
                    };
    
                    geometry = new StreamGeometry();
                    var gc = geometry.Open();
    
                    foreach (var elt in str) {
                        if (elt == 'F') {
                            var new_x = state.x + state.size * Math.Cos(state.dir * Math.PI / 180.0);
                            var new_y = state.y + state.size * Math.Sin(state.dir * Math.PI / 180.0);
                            var p1 = new Point(state.x, state.y);
                            var p2 = new Point(new_x, new_y); 
                            gc.BeginFigure(p1,false,false);
                            gc.LineTo(p2,true,true);
                    
    
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
                    gc.Close();
                    geometry.Freeze();
                };
    
                Action populateCanvas = () => {
                    Console.WriteLine(".");
    
                    lsystem_view.RenderTransform = new TranslateTransform(400,400);
    
                    lsystem_view.Redraw((dc) => {
                        dc.DrawGeometry(null, pen, geometry);
                    });
                };
    
                MouseDown += (s, e) => {
                    angleGrowth += 0.001;
                    Console.WriteLine("angleGrowth: {0}", angleGrowth);
    
                    var sw = Stopwatch.StartNew();
    
                    buildGeometry();
                    populateCanvas();
    
                    sw.Stop();
    
                    Console.WriteLine(sw.Elapsed);
                };
    
                buildGeometry();
    
                populateCanvas();
            }
        }
    }
