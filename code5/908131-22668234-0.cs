        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
        }
        /// <summary>
        /// The ClientToScreen function converts the client-area coordinates of a specified point to screen coordinates.
        /// </summary>
        /// <param name="hWnd">Handle to the window whose client area is used for the conversion.</param>
        /// <param name="pt">Pointer to a POINT structure that contains the client coordinates to be converted. The new screen coordinates are copied into this structure if the function succeeds.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("User32", EntryPoint = "ClientToScreen", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ClientToScreen(
            IntPtr hWnd,
            ref POINT pt);
        /// <summary>
        /// Code for getting screen relative Position in WPF
        /// </summary>
        /// <param name="point">The source point to be trasnformed</param>
        /// <param name="relativeTo">The Visual object used as reference</param>
        /// <returns>The screen-relative point obtained by the trasformation</returns>
        /// <remarks>
        /// http://blogs.msdn.com/llobo/archive/2006/05/02/Code-for-getting-screen-relative-Position-in-WPF.aspx
        /// One of the common customer queries that we see on the forums 
        /// is to get the screen relative position of  a point.
        /// Currently we do not provide an API which allows this functionality.
        /// However, Nick Kramer came up with this code on the forum 
        /// and it works great for LTR (left to right) systems. 
        /// Following is the code for getting the screen relative position.
        /// </remarks>
        [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public static Point? TransformToScreen(
            Point point,
            Visual relativeTo)
        {
            // Translate the point from the visual to the root.
            var hwndSource = PresentationSource.FromVisual(relativeTo) as HwndSource;
            if (hwndSource == null)
                return null;
            var root = hwndSource.RootVisual;
            // Transform the point from the root to client coordinates.
            var transformToRoot = relativeTo.TransformToAncestor(root);
            var pointRoot = transformToRoot.Transform(point);
            var m = Matrix.Identity;
            var transform = VisualTreeHelper.GetTransform(root);
            if (transform != null)
            {
                m = Matrix.Multiply(m, transform.Value);
            }
            // Convert from “device-independent pixels” into pixels.
            var offset = VisualTreeHelper.GetOffset(root);
            m.Translate(offset.X, offset.Y);
            var pointClient = m.Transform(pointRoot);
            pointClient = hwndSource.CompositionTarget.TransformToDevice.Transform(pointClient);
            var pointClientPixels = new POINT();
            pointClientPixels.X = (0 < pointClient.X)
                ? (int)(pointClient.X + 0.5)
                : (int)(pointClient.X - 0.5);
            pointClientPixels.Y = (0 < pointClient.Y)
                ? (int)(pointClient.Y + 0.5)
                : (int)(pointClient.Y - 0.5);
            // Transform the point into screen coordinates.
            var pointScreenPixels = pointClientPixels;
            if (ClientToScreen(
                hwndSource.Handle,
                ref pointScreenPixels))
            {
                return new Point(
                    pointScreenPixels.X,
                    pointScreenPixels.Y);
            }
            else
            {
                return new Point();
            }
        }
