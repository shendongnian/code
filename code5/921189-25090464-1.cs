    [Export(typeof(ITextViewModelProvider)), ContentType("CSharp"), TextViewRole("CustomProjectionRole")]
	internal class ProjectionTextViewModelProvider : ITextViewModelProvider
	{
		public ITextViewModel CreateTextViewModel(ITextDataModel dataModel, ITextViewRoleSet roles)
		{
			//Create a projection buffer based on the specified start and end position.
			var projectionBuffer = CreateProjectionBuffer(dataModel);
			//Display this projection buffer in the visual buffer, while still maintaining
			//the full file buffer as the underlying data buffer.
			var textViewModel = new ProjectionTextViewModel(dataModel, projectionBuffer);
			return textViewModel;
		}
		public IProjectionBuffer CreateProjectionBuffer(ITextDataModel dataModel)
		{
			//retrieve start and end position that we saved in MyToolWindow.CreateEditor()
			var startPosition = (int)dataModel.DataBuffer.Properties.GetProperty("StartPosition");
			var endPosition = (int)dataModel.DataBuffer.Properties.GetProperty("EndPosition");
			var length = endPosition - startPosition;
			//Take a snapshot of the text within these indices.
			var textSnapshot = dataModel.DataBuffer.CurrentSnapshot;
			var trackingSpan = textSnapshot.CreateTrackingSpan(startPosition, length, SpanTrackingMode.EdgeExclusive);
			//Create the actual projection buffer
			var projectionBuffer = ProjectionBufferFactory.CreateProjectionBuffer(
				null
				, new List<object>() { trackingSpan }
				, ProjectionBufferOptions.None
				);
			return projectionBuffer;
		}
		
		[Import]
		public IProjectionBufferFactoryService ProjectionBufferFactory { get; set; }
	}
