        public class TextRangeToolTip
        {
            public int StartPosition { get; set; }
            public int Length { get; set; }
            public object ToolTip { get; set; }
            internal bool IsInRange(int position)
            {
                return this.StartPosition <= position && position < this.StartPosition + this.Length;
            }
        }
        public class TextRangeToolTipCollection : ObservableCollection<TextRangeToolTip> {}
        [ContentProperty("Ranges")]
        public class ToolTipBehavior : Behavior<RichTextBox>
        {
            private const int ToolTipHideMouseDelta = 9;
            public static readonly DependencyProperty RangesProperty
                = DependencyProperty.Register("Ranges", typeof(TextRangeToolTipCollection),
                                              typeof (ToolTipBehavior),
                                              new PropertyMetadata(OnRangesChanged));
            private readonly DispatcherTimer timer;
            private readonly ToolTip toolTip;
            private Point lastMousePosition;
            public TextRangeToolTipCollection Ranges
            {
                get
                {
                    return (TextRangeToolTipCollection)this.GetValue(RangesProperty)
                           ?? (this.Ranges = new TextRangeToolTipCollection());
                }
                set { this.SetValue(RangesProperty, value); }
            }
            public ToolTipBehavior()
            {
                this.Ranges = new TextRangeToolTipCollection();
                this.timer = new DispatcherTimer();
                this.timer.Tick += this.TimerOnTick;
                this.timer.Interval = TimeSpan.FromSeconds(1);
                this.toolTip = new ToolTip {Placement = PlacementMode.Relative};
            }
            protected override void OnAttached()
            {
                this.AssociatedObject.ToolTip = this.toolTip;
                this.toolTip.PlacementTarget = this.AssociatedObject;
                ToolTipService.SetIsEnabled(this.AssociatedObject, false);
                this.AssociatedObject.MouseMove += this.AssociatedObjectOnMouseMove;
            }
            protected override void OnDetaching()
            {
                this.timer.Stop();
                this.toolTip.PlacementTarget = null;
                this.AssociatedObject.ToolTip = null;
                this.AssociatedObject.ClearValue(ToolTipService.IsEnabledProperty);
                this.AssociatedObject.MouseMove -= this.AssociatedObjectOnMouseMove;
            }
            private void AssociatedObjectOnMouseMove(object sender, MouseEventArgs mouseEventArgs)
            {
                Point currentMousePosition = mouseEventArgs.GetPosition(this.AssociatedObject);
                if (this.AssociatedObject.IsMouseCaptured)
                {
                    Vector delta = currentMousePosition
                                   - this.lastMousePosition;
                    if (delta.X*delta.X + delta.Y*delta.Y <= ToolTipHideMouseDelta)
                    {
                        this.toolTip.HorizontalOffset = currentMousePosition.X + 10;
                        this.toolTip.VerticalOffset = currentMousePosition.Y + 10;
                        return;
                    }
                    this.AssociatedObject.ReleaseMouseCapture();
                    this.toolTip.IsOpen = false;
                }
                if (this.AssociatedObject.IsMouseOver)
                {
                    this.lastMousePosition = currentMousePosition;
                    this.timer.Stop();
                    this.timer.Start();
                }
            }
            private static void OnRangesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                ((ToolTipBehavior) d).OnRangesChanged((IEnumerable<TextRangeToolTip>) e.OldValue,
                                                      (IEnumerable<TextRangeToolTip>) e.NewValue);
            }
            private void OnRangesChanged(IEnumerable<TextRangeToolTip> oldRanges, IEnumerable<TextRangeToolTip> newRanges)
            {
                var oldObservable = oldRanges as INotifyCollectionChanged;
                if (oldObservable != null)
                {
                    CollectionChangedEventManager.RemoveHandler(oldObservable, this.OnRangesCollectionChanged);
                }
                var newObservable = newRanges as INotifyCollectionChanged;
                if (newObservable != null)
                {
                    CollectionChangedEventManager.AddHandler(newObservable, this.OnRangesCollectionChanged);
                }
                this.UpdateToolTip();
            }
            private void OnRangesCollectionChanged(
                object sender,
                NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
            {
                this.UpdateToolTip();
            }
            private bool SetToolTipData()
            {
                if (this.Ranges == null)
                {
                    return false;
                }
                TextPointer pointer = this.AssociatedObject.GetPositionFromPoint(this.lastMousePosition, false);
                if (pointer == null)
                {
                    return false;
                }
                int position = this.AssociatedObject.Document.ContentStart.GetOffsetToPosition(pointer);
                TextRangeToolTip matchingRange = this.Ranges.FirstOrDefault(r => r.IsInRange(position));
                if (matchingRange == null)
                {
                    return false;
                }
                this.toolTip.Content = matchingRange.ToolTip;
                return true;
            }
            private void TimerOnTick(object sender, EventArgs eventArgs)
            {
                this.timer.Stop();
                if (this.AssociatedObject.IsMouseOver && this.SetToolTipData())
                {
                    this.toolTip.IsOpen = true;
                    this.AssociatedObject.CaptureMouse();
                }
            }
            private void UpdateToolTip()
            {
                if (this.AssociatedObject != null && this.AssociatedObject.IsMouseCaptured && !this.SetToolTipData())
                {
                    this.toolTip.IsOpen = false;
                    this.AssociatedObject.ReleaseMouseCapture();
                }
            }
        }
