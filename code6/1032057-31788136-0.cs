            try
            {
                geolocator = new Geolocator();
                geolocator.DesiredAccuracy = PositionAccuracy.High;
                geolocator.ReportInterval = 2000;
                geolocator.PositionChanged += geolocator_PositionChanged;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Location  is Disabled in Phone Settings.");
            }
            private void geolocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
            {
            try
            {
                Dispatcher.BeginInvoke(() =>
                {
                    if (args.Position != null && args.Position.Coordinate.ToGeoCoordinate() != myPosition)
                    {
                        if(args.Position.Coordinate.Accuracy <= 1500)
                        {
                            myPosition = args.Position.Coordinate.ToGeoCoordinate();
                            UpDateMyPositionCircle(args.Position.Coordinate.Accuracy);
                        }
                    }
                });
            } 
            catch (TargetInvocationException tie) 
            {
                if (tie.Data == null) throw;
                else MessageBox.Show("TargetInvocationException while Tracking: " + tie.InnerException.ToString());                    
            }
            catch(SystemException se)
            {
                if (se.Data == null) throw;
                else MessageBox.Show("SystemException while Tracking: " + se.InnerException.ToString());
            }
            catch(Exception ex)
            {
                if (ex.Data == null) throw;
                else MessageBox.Show("Exception while Tracking: " + ex.InnerException.ToString());
            }
        }
