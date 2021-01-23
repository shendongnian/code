    public interface IWidgetRepository
    {
        // Query methods
        Widget GetById(string id);
        IEnumerable<Widget> GetAll();
        // Update methods
        void RenameWidget(string id, string newName);
        void UpdateWidgetPrice(string id, decimal newPrice);
    }
