    public class QuotePageViewModel : PageViewModel
    {
        public IEnumerable<QuotesOverviewViewModel> LiveQuotes { get; set; }
        public PaginatedViewModel<QuotesOverviewViewModel> ArchivedQuotes { get; set; }
        public ItemViewModel SelectedItem { get; set; }
    }
