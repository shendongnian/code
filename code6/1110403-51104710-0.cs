            /// <summary>
        /// Reduce CPU Consumption for WPF Animations according to computer performance
        /// WPF draws animations at 60 frames per second. You can reduce this to a lower optimal rate, resulting in less CPU usage.
        /// </summary>
        /// <param name="fps"></param>
        private void Optimize()
        {
            int displayTier = (RenderCapability.Tier >> 16);
            if (displayTier < 2) // No hardware acceleration
            {
                RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
                Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata { DefaultValue = 24 });
            }
            else // Supports hardware acceleration
            {
                RenderOptions.ProcessRenderMode = RenderMode.Default;
                Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata { DefaultValue = 60 });
            }          
        }
