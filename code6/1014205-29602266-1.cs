         private async void LvPictures_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
          {
              ScrollViewer view = (ScrollViewer)sender;
              double progress = view.VerticalOffset / view.ScrollableHeight;
              if (progress > 0.8 & !_incallFilesList && NextPagePicturesAvailable)
              {
                  _incallFilesList = true;
                  GetNextPicturesPageAsync();
              }
              _incallFilesList = false;
          }
