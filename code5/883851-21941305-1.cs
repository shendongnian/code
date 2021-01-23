    public interface IWidgetRepository
    {
        // Query methods
        Widget GetById(string id);
        IEnumerable<Widget> GetFeaturedWidgets();
        IEnumerable<Widget> GetRecommendedWidgetsForUser(string userId);
    
        // Update methods
        void RenameWidget(string id, string newName);
        void UpdateWidgetPrice(string id, decimal newPrice);
    }
