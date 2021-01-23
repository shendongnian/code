    public static readonly DependencyProperty XPositionProperty =
        DependencyProperty.Register("XPosition", typeof(int), typeof(BoardSquare),
                                    new PropertyChangedCallback((obj, args) => { 
                                        BoardSquare bs = obj as BoardSquare;
                                        bs.Location.X = (int)args.NewValue;
                                        bs.resetBackgroundColorToPosition();
                                    })));
