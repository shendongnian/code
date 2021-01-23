        public void SendCardToPile(UIElement bigCard, UIElement targetElement)
        {
            this.ZoomDropShadowImage.Visibility = Visibility.Collapsed;
            
            double stopDelay = 2;
            double disappearSpeed = .5;
            // setup
            var _Scale = new ScaleTransform
            {
                ScaleX = 1.0,
                ScaleY = 1.0,
                CenterX = 0,
                CenterY = 0
            };
            this.ZoomItemCard.Visibility = Visibility.Visible;
            var _Translate = new TranslateTransform();
            var _Group = new TransformGroup();
            _Group.Children.Add(_Scale);
            _Group.Children.Add(_Translate);
            bigCard.RenderTransform = _Group;
            // animate
            var _Storyboard = new Storyboard { };
            var transform = targetElement.TransformToVisual(Application.Current.RootVisual as FrameworkElement);
            Point absolutePosition = transform.Transform(new Point(0, 0));
            // translate (location X)
            DoubleAnimationUsingKeyFrames _TranslateAnimateX = new DoubleAnimationUsingKeyFrames();
            System.Windows.Media.Animation.Storyboard.SetTarget(_TranslateAnimateX, _Translate);
            System.Windows.Media.Animation.Storyboard.SetTargetProperty(_TranslateAnimateX, new PropertyPath(TranslateTransform.XProperty));
            _TranslateAnimateX.KeyFrames.Add(new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0)),
                Value = -(Application.Current.Host.Content.ActualHeight / 2),
            });
            _TranslateAnimateX.KeyFrames.Add(new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(.25)),
                Value = (Application.Current.Host.Content.ActualHeight - 250) / 2
            });
            _TranslateAnimateX.KeyFrames.Add(new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(stopDelay)),
                Value = (Application.Current.Host.Content.ActualHeight - 250) / 2
            });
            _TranslateAnimateX.KeyFrames.Add(new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(stopDelay + disappearSpeed)),
                Value = absolutePosition.X
            });
            _Storyboard.Children.Add(_TranslateAnimateX);
            // translate (location Y)
            DoubleAnimationUsingKeyFrames _TranslateAnimateY = new DoubleAnimationUsingKeyFrames();
            System.Windows.Media.Animation.Storyboard.SetTarget(_TranslateAnimateY, _Translate);
            System.Windows.Media.Animation.Storyboard.SetTargetProperty(_TranslateAnimateY, new PropertyPath(TranslateTransform.YProperty));
            _TranslateAnimateY.KeyFrames.Add(new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0)),
                Value = (Application.Current.Host.Content.ActualWidth - 400) / 2
            });
            _TranslateAnimateY.KeyFrames.Add(new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(.25)),
                Value = (Application.Current.Host.Content.ActualWidth - 400) / 2
            });
            _TranslateAnimateY.KeyFrames.Add(new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(stopDelay)),
                Value = (Application.Current.Host.Content.ActualWidth - 400) / 2
            });
            _TranslateAnimateY.KeyFrames.Add(new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(stopDelay + disappearSpeed)),
                Value = absolutePosition.Y
            });
            _Storyboard.Children.Add(_TranslateAnimateY);
            // scale X
            DoubleAnimationUsingKeyFrames _ScaleAnimateX = new DoubleAnimationUsingKeyFrames();
            System.Windows.Media.Animation.Storyboard.SetTarget(_ScaleAnimateX, _Scale);
            System.Windows.Media.Animation.Storyboard.SetTargetProperty(_ScaleAnimateX, new PropertyPath(ScaleTransform.ScaleXProperty));
            _ScaleAnimateX.KeyFrames.Add(new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(stopDelay)),
                Value = 1.0
            });
            _ScaleAnimateX.KeyFrames.Add(new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(stopDelay + disappearSpeed)),
                Value = 0.0
            });
            _Storyboard.Children.Add(_ScaleAnimateX);
            // scale Y
            DoubleAnimationUsingKeyFrames _ScaleAnimateY = new DoubleAnimationUsingKeyFrames();
            System.Windows.Media.Animation.Storyboard.SetTarget(_ScaleAnimateY, _Scale);
            System.Windows.Media.Animation.Storyboard.SetTargetProperty(_ScaleAnimateY, new PropertyPath(ScaleTransform.ScaleYProperty));
            _ScaleAnimateY.KeyFrames.Add(new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(stopDelay)),
                Value = 1.0
            });
            _ScaleAnimateY.KeyFrames.Add(new LinearDoubleKeyFrame
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(stopDelay + disappearSpeed)),
                Value = 0.0
            });
            _Storyboard.Children.Add(_ScaleAnimateY);
            // finalize
            //EventHandler eh = null;
            //eh = (s, args) =>
            //{
            //    _Storyboard.Completed -= eh;
            //};
            //_Storyboard.Completed += eh;
            _Storyboard.Begin();
        }
