        public static IEnumerable<Capture> CapturesWithin(this Group source, Capture captureContainingGroup)
        {
            var lowerIndex = captureContainingGroup.Index;
            var upperIndex = lowerIndex + captureContainingGroup.Length - 1;
            foreach (var capture in source.Captures.Cast<Capture>())
            {
                if (capture.Index < lowerIndex)
                {
                    continue;
                }
                if (capture.Index > upperIndex)
                {
                    break;
                }
                yield return capture;
            }
        }
