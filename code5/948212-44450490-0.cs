    using System.Collections.Generic;
    using iTextSharp.text.pdf.parser;
    
    namespace Logic
    {
    	public class LocationTextExtractionStrategyWithPosition : LocationTextExtractionStrategy
    	{
    		private readonly List<TextChunk> locationalResult = new List<TextChunk>();
    
    		private readonly ITextChunkLocationStrategy tclStrat;
    
    		public LocationTextExtractionStrategyWithPosition() : this(new TextChunkLocationStrategyDefaultImp()) {
    		}
    
    		/**
             * Creates a new text extraction renderer, with a custom strategy for
             * creating new TextChunkLocation objects based on the input of the
             * TextRenderInfo.
             * @param strat the custom strategy
             */
    		public LocationTextExtractionStrategyWithPosition(ITextChunkLocationStrategy strat)
    		{
    			tclStrat = strat;
    		}
    		
    
    		private bool StartsWithSpace(string str)
    		{
    			if (str.Length == 0) return false;
    			return str[0] == ' ';
    		}
    
    	
    		private bool EndsWithSpace(string str)
    		{
    			if (str.Length == 0) return false;
    			return str[str.Length - 1] == ' ';
    		}
    
    		/**
             * Filters the provided list with the provided filter
             * @param textChunks a list of all TextChunks that this strategy found during processing
             * @param filter the filter to apply.  If null, filtering will be skipped.
             * @return the filtered list
             * @since 5.3.3
             */
    
    		private List<TextChunk> filterTextChunks(List<TextChunk> textChunks, ITextChunkFilter filter)
    		{
    			if (filter == null)
    			{
    				return textChunks;
    			}
    
    			var filtered = new List<TextChunk>();
    
    			foreach (var textChunk in textChunks)
    			{
    				if (filter.Accept(textChunk))
    				{
    					filtered.Add(textChunk);
    				}
    			}
    
    			return filtered;
    		}
    
    		public override void RenderText(TextRenderInfo renderInfo)
    		{
    			LineSegment segment = renderInfo.GetBaseline();
    			if (renderInfo.GetRise() != 0)
    			{ // remove the rise from the baseline - we do this because the text from a super/subscript render operations should probably be considered as part of the baseline of the text the super/sub is relative to 
    				Matrix riseOffsetTransform = new Matrix(0, -renderInfo.GetRise());
    				segment = segment.TransformBy(riseOffsetTransform);
    			}
    			TextChunk tc = new TextChunk(renderInfo.GetText(), tclStrat.CreateLocation(renderInfo, segment));
    			locationalResult.Add(tc);
    		}
    		
    
    		public IList<TextLocation> GetLocations()
    		{
    
    			var filteredTextChunks = filterTextChunks(locationalResult, null);
    			filteredTextChunks.Sort();
    
    			TextChunk lastChunk = null;
    
    			 var textLocations = new List<TextLocation>();
    
    			foreach (var chunk in filteredTextChunks)
    			{
    
    				if (lastChunk == null)
    				{
    					//initial
    					textLocations.Add(new TextLocation
    					{
    						Text = chunk.Text,
    						X = iTextSharp.text.Utilities.PointsToMillimeters(chunk.Location.StartLocation[0]),
    						Y = iTextSharp.text.Utilities.PointsToMillimeters(chunk.Location.StartLocation[1])
    					});
    
    				}
    				else
    				{
    					if (chunk.SameLine(lastChunk))
    					{
    						var text = "";
    						// we only insert a blank space if the trailing character of the previous string wasn't a space, and the leading character of the current string isn't a space
    						if (IsChunkAtWordBoundary(chunk, lastChunk) && !StartsWithSpace(chunk.Text) && !EndsWithSpace(lastChunk.Text))
    							text += ' ';
    
    						text += chunk.Text;
    
    						textLocations[textLocations.Count - 1].Text += text;
    
    					}
    					else
    					{
    
    						textLocations.Add(new TextLocation
    						{
    							Text = chunk.Text,
    							X = iTextSharp.text.Utilities.PointsToMillimeters(chunk.Location.StartLocation[0]),
    							Y = iTextSharp.text.Utilities.PointsToMillimeters(chunk.Location.StartLocation[1])
    						});
    					}
    				}
    				lastChunk = chunk;
    			}
    
    			//now find the location(s) with the given texts
    			return textLocations;
    			
    		}
    	
    	}
    
    	public class TextLocation
    	{
    		public float X { get; set; }
    		public float Y { get; set; }
    
    		public string Text { get; set; }
    	}
    }
		
