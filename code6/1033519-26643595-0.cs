    /// <summary>
    /// Consolidates horizontal and vertical lines.
    /// </summary>
    class LineConsolidator : IEnumerable<LineConsolidator.Line>
    {
        /// <summary>
        /// A pair of points defining a line
        /// </summary>
        public struct Line
        {
            public Point Start { get; private set; }
            public Point End { get; private set; }
            public Line(Point start, Point end)
                : this()
            {
                Start = start;
                End = end;
            }
        }
        private struct Segment
        {
            public int Start { get; private set; }
            public int End { get; private set; }
            public Segment(int start, int end)
                : this()
            {
                if (end < start)
                {
                    throw new ArgumentException("start must be less than or equal to end");
                }
                Start = start;
                End = end;
            }
            public Segment Union(Segment other)
            {
                if (End < other.Start || other.End < Start)
                {
                    throw new ArgumentException("Only overlapping segments may be consolidated");
                }
                return new Segment(
                        Math.Min(Start, other.Start),
                        Math.Max(End, other.End));
            }
            public Segment? Intersect(Segment other)
            {
                int start = Math.Max(Start, other.Start),
                    end = Math.Min(End, other.End);
                if (end < start)
                {
                    return null;
                }
                return new Segment(start, end);
            }
        }
        private Dictionary<int, List<Segment>> _horizontalLines = new Dictionary<int, List<Segment>>();
        private Dictionary<int, List<Segment>> _verticalLines = new Dictionary<int, List<Segment>>();
        /// <summary>
        /// Add horizontal line
        /// </summary>
        /// <param name="y">The Y coordinate of the line to add</param>
        /// <param name="start">The first X coordinate of the line to add (must not be larger than <paramref name="end"/></param>
        /// <param name="end">The second X coordinate of the line to add (must not be smaller than <paramref name="start"/></param>
        /// <remarks>
        /// This method submits a new horizontal line to the collection. It is merged with any other
        /// horizontal lines with exactly the same Y coordinate that it overlaps.
        /// </remarks>
        public void AddHorizontal(int y, int start, int end)
        {
            _AddLine(y, new Segment(start, end), _horizontalLines);
        }
        /// <summary>
        /// Add vertical line
        /// </summary>
        /// <param name="y">The X coordinate of the line to add</param>
        /// <param name="start">The first Y coordinate of the line to add (must not be larger than <paramref name="end"/></param>
        /// <param name="end">The second Y coordinate of the line to add (must not be smaller than <paramref name="start"/></param>
        /// <remarks>
        /// This method submits a new vertical line to the collection. It is merged with any other
        /// vertical lines with exactly the same X coordinate that it overlaps.
        /// </remarks>
        public void AddVertical(int x, int start, int end)
        {
            _AddLine(x, new Segment(start, end), _verticalLines);
        }
        /// <summary>
        /// Add all four sides of a rectangle as individual lines
        /// </summary>
        /// <param name="rect">The rectangle containing the lines to add</param>
        public void AddRectangle(Rectangle rect)
        {
            AddHorizontal(rect.Top, rect.Left, rect.Right);
            AddHorizontal(rect.Bottom, rect.Left, rect.Right);
            AddVertical(rect.Left, rect.Top, rect.Bottom);
            AddVertical(rect.Right, rect.Top, rect.Bottom);
        }
        /// <summary>
        /// Gets all of the horizontal lines in the collection
        /// </summary>
        public IEnumerable<Line> HorizontalLines
        {
            get
            {
                foreach (var kvp in _horizontalLines)
                {
                    foreach (var segment in kvp.Value)
                    {
                        yield return new Line(new Point(segment.Start, kvp.Key), new Point(segment.End, kvp.Key));
                    }
                }
            }
        }
        /// <summary>
        /// Gets all of the vertical lines in the collection
        /// </summary>
        public IEnumerable<Line> VerticalLines
        {
            get
            {
                foreach (var kvp in _verticalLines)
                {
                    foreach (var segment in kvp.Value)
                    {
                        yield return new Line(new Point(kvp.Key, segment.Start), new Point(kvp.Key, segment.End));
                    }
                }
            }
        }
        private static void _AddLine(int lineKey, Segment newSegment, Dictionary<int, List<Segment>> segmentKeyToSegments)
        {
            // Get the list of segments for the given key (X for vertical lines, Y for horizontal lines)
            List<Segment> segments;
            if (!segmentKeyToSegments.TryGetValue(lineKey, out segments))
            {
                segments = new List<Segment>();
                segmentKeyToSegments[lineKey] = segments;
            }
            int isegmentInsert = 0, isegmentMergeFirst = -1, ilineSegmentLast = -1;
            // Find all existing segments that should be merged with the new one
            while (isegmentInsert < segments.Count && segments[isegmentInsert].Start <= newSegment.End)
            {
                Segment? intersectedSegment = newSegment.Intersect(segments[isegmentInsert]);
                if (intersectedSegment != null)
                {
                    // If they overlap, merge them together, keeping track of all the existing
                    // segments which were merged
                    newSegment = newSegment.Union(segments[isegmentInsert]);
                    if (isegmentMergeFirst == -1)
                    {
                        isegmentMergeFirst = isegmentInsert;
                    }
                    ilineSegmentLast = isegmentInsert;
                }
                isegmentInsert++;
            }
            if (isegmentMergeFirst == -1)
            {
                // If there was no merge, just insert the new segment
                segments.Insert(isegmentInsert, newSegment);
            }
            else
            {
                // If more than one segment was merged, remove all but one
                if (ilineSegmentLast > isegmentMergeFirst)
                {
                    segments.RemoveRange(isegmentMergeFirst + 1, ilineSegmentLast - isegmentMergeFirst);
                }
                // Copy the new, merged segment back to the first original segment's slot
                segments[isegmentMergeFirst] = newSegment;
            }
        }
        public IEnumerator<LineConsolidator.Line> GetEnumerator()
        {
            return HorizontalLines.Concat(VerticalLines).GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
