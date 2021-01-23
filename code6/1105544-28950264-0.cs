	class Paginator : DocumentPaginator
	{
		public override DocumentPage GetPage(int pageNumber)
		{
			if (pageNumber == 0)
			{
				Canvas printCanvas = new Canvas();
				printCanvas.Measure(PageSize);
				return new DocumentPage(printCanvas);
			}
			else
			{
				// deal with other pages
				throw new NotImplementedException();
			}
		}
		public override bool IsPageCountValid
		{
			get { return true; }
		}
		public override int PageCount
		{
			get { return 1; }
		}
		public override Size PageSize
		{
			get
			{
				return new Size(8.5,11);
			}
			set
			{
				throw new NotImplementedException();
			}
		}
		public override IDocumentPaginatorSource Source
		{
			get { return null; }
		}
	}
