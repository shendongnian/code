    InkManager MyInkManager = new InkManager();
            string DrawingTool;
            double X1, X2, Y1, Y2, StrokeThickness = 1;
            Line NewLine;
            Ellipse NewEllipse;
            Point StartPoint, PreviousContactPoint, CurrentContactPoint;
            Polyline Pencil;
            Rectangle NewRectangle;
            Color BorderColor = Colors.Black, FillColor;
            uint PenID, TouchID;
    
    public MainPage()
            {
                this.InitializeComponent();
                canvas.PointerMoved += canvas_PointerMoved;
                canvas.PointerReleased += canvas_PointerReleased;
                canvas.PointerPressed += canvas_PointerPressed;
                canvas.PointerExited += canvas_PointerExited;
                
                for (int i = 1; i < 21; i++)
                {
                    ComboBoxItem Items = new ComboBoxItem();
                    Items.Content = i;
                    cbStrokeThickness.Items.Add(Items);
                }
                cbStrokeThickness.SelectedIndex = 0;
                
                //var t = typeof(Colors);
                //var ti = t.GetTypeInfo();
                //var dp = ti.DeclaredProperties;
    
                var colors = typeof(Colors).GetTypeInfo().DeclaredProperties;
                foreach (var item in colors)
                {
                    cbBorderColor.Items.Add(item);
                    cbFillColor.Items.Add(item);
                }
            }
    
    
    then we need to define the canvas pointer events.here i am giving one example lets say pointer move event
    
    
    
     void canvas_PointerMoved(object sender, PointerRoutedEventArgs e)
            {
                if (DrawingTool != "Eraser")
                    Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.Cross, 1);
                else
                    Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.UniversalNo, 1);
    
                switch (DrawingTool)
                {
                    case "Pencil":
                        {
                            /* Old Code
                            if (e.GetCurrentPoint(canvas).Properties.IsLeftButtonPressed == true)
                            {
                                if (StartPoint != e.GetCurrentPoint(canvas).Position)
                                {
                                    Pencil.Points.Add(e.GetCurrentPoint(canvas).Position);
                                }
                            }
                            */
    
                            if (e.Pointer.PointerId == PenID || e.Pointer.PointerId == TouchID)
                            {
                                // Distance() is an application-defined function that tests
                                // whether the pointer has moved far enough to justify 
                                // drawing a new line.
                                CurrentContactPoint = e.GetCurrentPoint(canvas).Position;
                                X1 = PreviousContactPoint.X;
                                Y1 = PreviousContactPoint.Y;
                                X2 = CurrentContactPoint.X;
                                Y2 = CurrentContactPoint.Y;
    
                                if (Distance(X1, Y1, X2, Y2) > 2.0)
                                {
                                    Line line = new Line()
                                    {
                                        X1 = X1,
                                        Y1 = Y1,
                                        X2 = X2,
                                        Y2 = Y2,
                                        StrokeThickness = StrokeThickness,
                                        Stroke = new SolidColorBrush(BorderColor)
                                    };
    
                                    PreviousContactPoint = CurrentContactPoint;
                                    canvas.Children.Add(line);
                                    MyInkManager.ProcessPointerUpdate(e.GetCurrentPoint(canvas));
                                }
                            }
                        }
                        break;
    
                    case "Line":
                        {
                            if (e.GetCurrentPoint(canvas).Properties.IsLeftButtonPressed == true)
                            {
                                NewLine.X2 = e.GetCurrentPoint(canvas).Position.X;
                                NewLine.Y2 = e.GetCurrentPoint(canvas).Position.Y;
                            }
                        }
                        break;
    
                    case "Rectagle":
                        {
                            if (e.GetCurrentPoint(canvas).Properties.IsLeftButtonPressed == true)
                            {
                                X2 = e.GetCurrentPoint(canvas).Position.X;
                                Y2 = e.GetCurrentPoint(canvas).Position.Y;
                                if ((X2 - X1) > 0 && (Y2 - Y1) > 0)
                                    NewRectangle.Margin = new Thickness(X1, Y1, X2, Y2);
                                else if ((X2 - X1) < 0)
                                    NewRectangle.Margin = new Thickness(X2, Y1, X1, Y2);
                                else if ((Y2 - Y1) < 0)
                                    NewRectangle.Margin = new Thickness(X1, Y2, X2, Y1);
                                else if ((X2 - X1) < 0 && (Y2 - Y1) < 0)
                                    NewRectangle.Margin = new Thickness(X2, Y1, X1, Y2);
                                NewRectangle.Width = Math.Abs(X2 - X1);
                                NewRectangle.Height = Math.Abs(Y2 - Y1);
                            }
                        }
                        break;
    
                    case "Ellipse":
                        {
                            if (e.GetCurrentPoint(canvas).Properties.IsLeftButtonPressed == true)
                            {
                                X2 = e.GetCurrentPoint(canvas).Position.X;
                                Y2 = e.GetCurrentPoint(canvas).Position.Y;
                                if ((X2 - X1) > 0 && (Y2 - Y1) > 0)
                                    NewEllipse.Margin = new Thickness(X1, Y1, X2, Y2);
                                else if ((X2 - X1) < 0)
                                    NewEllipse.Margin = new Thickness(X2, Y1, X1, Y2);
                                else if ((Y2 - Y1) < 0)
                                    NewEllipse.Margin = new Thickness(X1, Y2, X2, Y1);
                                else if ((X2 - X1) < 0 && (Y2 - Y1) < 0)
                                    NewEllipse.Margin = new Thickness(X2, Y1, X1, Y2);
                                NewEllipse.Width = Math.Abs(X2 - X1);
                                NewEllipse.Height = Math.Abs(Y2 - Y1);
                            }
                        }
                        break;
    
                    case "Eraser":
                        {
                            if (e.GetCurrentPoint(canvas).Properties.IsLeftButtonPressed == true)
                            {
                                if (StartPoint != e.GetCurrentPoint(canvas).Position)
                                {
                                    Window.Current.CoreWindow.PointerCursor = new CoreCursor(CoreCursorType.UniversalNo, 1);
                                    Pencil.Points.Add(e.GetCurrentPoint(canvas).Position);
                                }
                            }
                        }
                        break;
    
                    default:
                        break;
                }
            }
    
    
    Then lets say we need to define the drawing tools click event as bellow
    
    private void btnPencil_Click(object sender, RoutedEventArgs e)
            {
                DrawingTool = "Pencil";
            }
    
            private void btnLine_Click(object sender, RoutedEventArgs e)
            {
                DrawingTool = "Line";
            }
    
            private void btnEllipse_Click(object sender, RoutedEventArgs e)
            {
                DrawingTool = "Ellipse";
            }
    
            private void btnRectagle_Click(object sender, RoutedEventArgs e)
            {
                DrawingTool = "Rectagle";
            }
    
            private void btnEraser_Click(object sender, RoutedEventArgs e)
            {
                DrawingTool = "Eraser";
            }
    
            private void btnClearScreen_Click(object sender, RoutedEventArgs e)
            {
                //MyInkManager.Mode = InkManipulationMode.Erasing;
                //for (int i = 0; i < MyInkManager.GetStrokes().Count; i++)
                //    MyInkManager.GetStrokes().ElementAt(i).Selected = true;
                //MyInkManager.DeleteSelected();
                txtRecognizedText.Text = string.Empty;
                canvas.Children.Clear();
            }
    
    Here i am giving you example of some of the event.
    Hope this will help you in some extent
