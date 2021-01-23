    using System;
    using System.Linq;
    
    //be sure to ref(using) this namespace in your Views you plan on using the HTML helper
    namespace PagedList.Mvc.Custom
    {
    	public class PagedListRenderOptions : PagedList.Mvc.PagedListRenderOptions
    	{
    		///<summary>
    		/// The default settings render all navigation links and no descriptive text.
    		///</summary>
    		public PagedListRenderOptions()
    		{
    			//dont change any of these values, instead, make a new static method below and override
                        DisplayLinkToFirstPage = PagedListDisplayMode.IfNeeded;
    			DisplayLinkToLastPage = PagedListDisplayMode.IfNeeded;
    			DisplayLinkToPreviousPage = PagedListDisplayMode.IfNeeded;
    			DisplayLinkToNextPage = PagedListDisplayMode.IfNeeded;
    			DisplayLinkToIndividualPages = true;
    			DisplayPageCountAndCurrentLocation = false;
    			MaximumPageNumbersToDisplay = 10;
    			DisplayEllipsesWhenNotShowingAllPageNumbers = true;
    			EllipsesFormat = "&#8230;";
    			LinkToFirstPageFormat = "««";
    			LinkToPreviousPageFormat = "«";
    			LinkToIndividualPageFormat = "{0}";
    			LinkToNextPageFormat = "»";
    			LinkToLastPageFormat = "»»";
    			PageCountAndCurrentLocationFormat = "Page {0} of {1}.";
    			ItemSliceAndTotalFormat = "Showing items {0} through {1} of {2}.";
    			FunctionToDisplayEachPageNumber = null;
    			ClassToApplyToFirstListItemInPager = null;
    			ClassToApplyToLastListItemInPager = null;
    			ContainerDivClasses = new[] { "pagination-container" };
    			UlElementClasses = new[] { "pagination" };
    			LiElementClasses = Enumerable.Empty<string>();
    		}
    
    		public static PagedListRenderOptions Bootstrap2
    		{
    			get
    			{
    				var a = new PagedListRenderOptions();
    				a.UlElementClasses = new[] { "" };
    				a.ContainerDivClasses = new[] { "pagination" };
    				return a;
    			}
    		}
    	}
    }
