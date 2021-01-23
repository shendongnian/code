            try
            {
                var hwndSource = PresentationSource.FromVisual(this) as HwndSource;
                var hwndTarget = hwndSource.CompositionTarget;
                hwndTarget.RenderMode = RenderMode.SoftwareOnly;
            }
            catch (Exception ex)
            {
                Log.ErrorException(ex.Message, ex);
            }
