      class LocationTextExtractionStrategyEx : LocationTextExtractionStrategy
    {
        private List<LocationTextExtractionStrategyEx.ExtendedTextChunk> m_DocChunks = new List<ExtendedTextChunk>();
        private List<LocationTextExtractionStrategyEx.LineInfo> m_LinesTextInfo = new List<LineInfo>();
        public List<SearchResult> m_SearchResultsList = new List<SearchResult>();
        private String m_SearchText;
        public const float PDF_PX_TO_MM = 0.3528f;
        public float m_PageSizeY;
       
        public LocationTextExtractionStrategyEx(String sSearchText, float fPageSizeY)
            : base()
        {
            this.m_SearchText = sSearchText;
            this.m_PageSizeY = fPageSizeY;
        }
        private void searchText()
        {
            foreach (LineInfo aLineInfo in m_LinesTextInfo)
            {
                int iIndex = aLineInfo.m_Text.IndexOf(m_SearchText);
                if (iIndex != -1)
                {
                    TextRenderInfo aFirstLetter = aLineInfo.m_LineCharsList.ElementAt(iIndex);
                    SearchResult aSearchResult = new SearchResult(aFirstLetter, m_PageSizeY);
                    this.m_SearchResultsList.Add(aSearchResult);
                }
            }
        }
        private void groupChunksbyLine()
        {                     
            LocationTextExtractionStrategyEx.ExtendedTextChunk textChunk1 = null;
            LocationTextExtractionStrategyEx.LineInfo textInfo = null;
            foreach (LocationTextExtractionStrategyEx.ExtendedTextChunk textChunk2 in this.m_DocChunks)
            {
                if (textChunk1 == null)
                {                    
                    textInfo = new LocationTextExtractionStrategyEx.LineInfo(textChunk2);
                    this.m_LinesTextInfo.Add(textInfo);
                }
                else if (textChunk2.sameLine(textChunk1))
                {                      
                    textInfo.appendText(textChunk2);
                }
                else
                {                                        
                    textInfo = new LocationTextExtractionStrategyEx.LineInfo(textChunk2);
                    this.m_LinesTextInfo.Add(textInfo);
                }
                textChunk1 = textChunk2;
            }
        }
        public override string GetResultantText()
        {
            groupChunksbyLine();
            searchText();
            //In this case the return value is not useful
            return "";
        }
        public override void RenderText(TextRenderInfo renderInfo)
        {
            LineSegment baseline = renderInfo.GetBaseline();
            //Create ExtendedChunk
            ExtendedTextChunk aExtendedChunk = new ExtendedTextChunk(renderInfo.GetText(), baseline.GetStartPoint(), baseline.GetEndPoint(), renderInfo.GetSingleSpaceWidth(), renderInfo.GetCharacterRenderInfos().ToList());
            this.m_DocChunks.Add(aExtendedChunk);
        }
        public class ExtendedTextChunk
        {
            public string m_text;
            private Vector m_startLocation;
            private Vector m_endLocation;
            private Vector m_orientationVector;
            private int m_orientationMagnitude;
            private int m_distPerpendicular;           
            private float m_charSpaceWidth;           
            public List<TextRenderInfo> m_ChunkChars;
                      
            public ExtendedTextChunk(string txt, Vector startLoc, Vector endLoc, float charSpaceWidth,List<TextRenderInfo> chunkChars)
            {
                this.m_text = txt;
                this.m_startLocation = startLoc;
                this.m_endLocation = endLoc;
                this.m_charSpaceWidth = charSpaceWidth;                
                this.m_orientationVector = this.m_endLocation.Subtract(this.m_startLocation).Normalize();
                this.m_orientationMagnitude = (int)(Math.Atan2((double)this.m_orientationVector[1], (double)this.m_orientationVector[0]) * 1000.0);
                this.m_distPerpendicular = (int)this.m_startLocation.Subtract(new Vector(0.0f, 0.0f, 1f)).Cross(this.m_orientationVector)[2];                
                this.m_ChunkChars = chunkChars;
            }
            
            public bool sameLine(LocationTextExtractionStrategyEx.ExtendedTextChunk textChunkToCompare)
            {
                return this.m_orientationMagnitude == textChunkToCompare.m_orientationMagnitude && this.m_distPerpendicular == textChunkToCompare.m_distPerpendicular;
            }
          
            
        }
        public class SearchResult
        {
            public int iPosX;
            public int iPosY;
            public SearchResult(TextRenderInfo aCharcter, float fPageSizeY)
            {
                //Get position of upperLeft coordinate
                Vector vTopLeft = aCharcter.GetAscentLine().GetStartPoint();
                //PosX
                float fPosX = vTopLeft[Vector.I1]; 
                //PosY
                float fPosY = vTopLeft[Vector.I2];
                //Transform to mm and get y from top of page
                iPosX = Convert.ToInt32(fPosX * PDF_PX_TO_MM);
                iPosY = Convert.ToInt32((fPageSizeY - fPosY) * PDF_PX_TO_MM);
            }
        }
        public class LineInfo
        {            
            public string m_Text;
            public List<TextRenderInfo> m_LineCharsList;
        
            public LineInfo(LocationTextExtractionStrategyEx.ExtendedTextChunk initialTextChunk)
            {                
                this.m_Text = initialTextChunk.m_text;
                this.m_LineCharsList = initialTextChunk.m_ChunkChars;
            }
            public void appendText(LocationTextExtractionStrategyEx.ExtendedTextChunk additionalTextChunk)
            {
                m_LineCharsList.AddRange(additionalTextChunk.m_ChunkChars);
                this.m_Text += additionalTextChunk.m_text;
            }
        }
    }
