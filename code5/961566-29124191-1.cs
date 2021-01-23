        bool hasAppearedOnce = false;
        protected override void OnAppearing() {
            base.OnAppearing();
            if (!hasAppearedOnce) {
                
                hasAppearedOnce = true;
                var padding = (NameGrid.Width - MessagesListView.Height) / 2;
                MessagesListView.HeightRequest = MessagesLayoutFrame.Width;
                MessagesLayoutFrameInner.WidthRequest = MessagesLayoutFrame.Width;
                MessagesLayoutFrameInner.Padding = new Thickness(0);
                MessagesLayoutFrame.Padding = new Thickness(0);
                MessagesLayoutFrame.IsClippedToBounds = true;
                Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(MessagesLayoutFrameInner, new Rectangle(0, 0 - padding, AbsoluteLayout.AutoSize, MessagesListView.Height - padding));
                MessagesLayoutFrameInner.IsClippedToBounds = true;
                 // */
            } 
        }
