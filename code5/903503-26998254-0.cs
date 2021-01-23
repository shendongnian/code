     /// <summary>
        /// Gets the automation identifier of underlying element.
        /// </summary>
        /// <returns></returns>
        public static string GetTheAutomationIDOfUnderlyingElement()
        {
            string requiredAutomationID = string.Empty;
            System.Drawing.Point currentLocation = Cursor.Position;//add you current location here
            AutomationElement aeOfRequiredPaneAtTop = GetElementFromPoint(currentLocation, 10, 100);
            if (aeOfRequiredPaneAtTop != null)
            {
                return aeOfRequiredPaneAtTop.Current.AutomationId;
            }
            return string.Empty;
        }
        /// <summary>
        /// Gets the element from point.
        /// </summary>
        /// <param name="startingPoint">The starting point.</param>
        /// <param name="interval">The interval.</param>
        /// <param name="maxLengthToTraverse">The maximum length to traverse.</param>
        /// <returns></returns>
        public static AutomationElement GetElementFromPoint(Point startingPoint, int interval, int maxLengthToTraverse)
        {
            AutomationElement requiredElement = null;
            for (Point p = startingPoint; ; )
            {
                requiredElement = AutomationElement.FromPoint(new System.Windows.Point(p.X, p.Y));
                Console.WriteLine(requiredElement.Current.Name);
                if (requiredElement.Current.ControlType.Equals(ControlType.Window))
                {
                    return requiredElement;
    
                }
                if (p.X > (startingPoint.X + maxLengthToTraverse))
                    break;
                p.X = p.X + interval;
            }
            return null;
        }
        
