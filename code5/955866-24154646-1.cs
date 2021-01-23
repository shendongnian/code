    // Clear the contents of the list used for hit test results.
                    hitResultsList.Clear();
                    // Set up a callback to receive the hit test result enumeration.
                    VisualTreeHelper.HitTest(pe.InkCanvas, null,
                        new HitTestResultCallback(MyHitTestResult),                        new PointHitTestParameters(point_MouseDown));
                    for (int i = 0; i < hitResultsList.Count; i++)
                    {
                        TextBlock tb = hitResultsList[i] as TextBlock;
                        if (tb == null) continue;
                        if (tb.Text == "Cancel")
                        {
                            Cancel_Click(); 
                        }
                    }
..................................................
    List<DependencyObject> hitResultsList = new List<DependencyObject>();
        // Return the result of the hit test to the callback. 
        public HitTestResultBehavior MyHitTestResult(HitTestResult result)
        {
            // Add the hit test result to the list that will be processed after the enumeration.
            hitResultsList.Add(result.VisualHit);
            // Set the behavior to return visuals at all z-order levels. 
            return HitTestResultBehavior.Continue;
        }
