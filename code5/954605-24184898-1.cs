    public class TestBinarySegment
    {
        public TestBinarySegment()
        {
            List<BinarySegment> myBinarySegments = new List<BinarySegment>();
            myBinarySegments.Add(new BinarySegment{SegmentName = "Segment1", SegmentStartIndex = 0, SegmentLength = 1111});
            myBinarySegments.Add(new BinarySegment { SegmentName = "Segment2", SegmentStartIndex = 1111, SegmentLength = 1111 });
            myBinarySegments.Add(new BinarySegment { SegmentName = "Segment3", SegmentStartIndex = 2222, SegmentLength = 1111 });
            BinarySegment.Save(myBinarySegments);
        }
        public void LoadAddSave()
        {
            List<BinarySegment> myBinarySegments = BinarySegment.LoadFromFile();
            myBinarySegments.Add(new BinarySegment { SegmentName = "Segment4", SegmentStartIndex = 333330, SegmentLength = 1111 });
            BinarySegment.Save(myBinarySegments);
        }
    }
