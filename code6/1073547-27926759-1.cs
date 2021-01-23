    public class ChunkExtractionStrategy : ITextExtractionStrategy
    {
        public List<Chunk> Chunks = new List<Chunk>();
        public void BeginTextBlock()
        {}
        public void EndTextBlock()
        {}
        public string GetResultantText()
        {
            var text = new StringBuilder();
            Chunks.Sort();
            Chunk prevChunk = null;
            foreach ( var chunk in Chunks )
            {
                if ( prevChunk == null && string.IsNullOrWhiteSpace( chunk.Text ) )
                {
                    // blank space at beginning of page
                    continue;
                }
                if ( prevChunk != null && !chunk.SameLine( prevChunk, 20 ) )
                {
                    text.Append( "\n\n" );
                }
                text.Append( chunk.Text );
                prevChunk = chunk;
            }
            return text.ToString();
        }
        public void RenderImage( ImageRenderInfo renderInfo )
        {}
        public void RenderText( TextRenderInfo renderInfo )
        {
            Chunks.Add( new Chunk
                            {
                                TopLeft = renderInfo.GetAscentLine().GetStartPoint(),
                                BottomRight = renderInfo.GetDescentLine().GetEndPoint(),
                                Text = renderInfo.GetText(),
                            } );
        }
        public class Chunk : IComparable<Chunk>
        {
            public Vector TopLeft { get; set; }
            public Vector BottomRight { get; set; }
            public string Text { get; set; }
            public int CompareTo( Chunk other )
            {
                var y1 = (int)Math.Round( TopLeft[1] );
                var y2 = (int)Math.Round( other.TopLeft[1] );
                if ( y1 < y2 )
                {
                    return 1;
                }
                if ( y1 > y2 )
                {
                    return -1;
                }
                var x1 = (int)Math.Round( TopLeft[0] );
                var x2 = (int)Math.Round( other.TopLeft[0] );
                if ( x1 < x2 )
                {
                    return -1;
                }
                if ( x1 > x2 )
                {
                    return 1;
                }
                return 0;
            }
            public bool SameLine( Chunk other, int maxDiff = 0 )
            {
                var diff = Math.Abs( TopLeft[1] - other.TopLeft[1] );
                return diff <= maxDiff;
            }
        }
    }
